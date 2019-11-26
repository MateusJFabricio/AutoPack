using OrganizadorGeometrico.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OrganizadorGeometrico.Controller
{
    class DXFController
    {
        private Organizer organizador = new Organizer();
        public DXFItem placaGravacao;
        public DXFItem figuraGeometricaAtual;
        public List<DXFItem> figurasGeometricas = new List<DXFItem>();
        private int idFiguraGeometrica = 0;
        public Queue<string> mensagens = new Queue<string>();
        public int FigurasProcessadas { get => organizador.progressoAlgoritmo;}
        public bool FigurasOrganizadas { get => organizador.sucessoOrganizador;}

        public Bitmap IniciarOrganizador()
        {
            if (placaGravacao == null)
                throw new Exception("Atencao! Nao há placa de gravacao!");

            if (figurasGeometricas.Count == 0)
                throw new Exception("Atencao! Nao há figuras geometricas para organizar!");

            mensagens.Enqueue("Iniciado o organizador");

            organizador.IniciarOrganizador(placaGravacao, figurasGeometricas);

            foreach (var log in organizador.log)
            {
                mensagens.Enqueue(log);
            }

            return organizador.GetBitmapResultado();
        }

        public Bitmap AdicionarPlacaGravacao(string path)
        {
            placaGravacao = new DXFItem();
            placaGravacao.InicializarDeArquivo(path, 0, true);

            //Valida se a figura geometrica esta aberta
            if (!placaGravacao.figuraFechada)
                throw new Exception("A figura geometrica deve fechada. Ha pontos abertos na figuras geometrica selecionada");

            figuraGeometricaAtual = placaGravacao;
            return placaGravacao.GetBitmap();
        }

        public Bitmap AdicionarFiguraGeometrica(string path)
        {
            DXFItem item = new DXFItem();
            item.InicializarDeArquivo(path, ++idFiguraGeometrica);
            figurasGeometricas.Add(item);
            figuraGeometricaAtual = item;
            return item.GetBitmap();
        }

        public void RemoverPlacaGravacao()
        {
            placaGravacao = null;
            figuraGeometricaAtual = null;
        }

        public void RemoverFiguraGeometrica(int id)
        {
            foreach (var fg in figurasGeometricas)
            {
                if (fg.id == id)
                {
                    figurasGeometricas.Remove(fg);
                    break;
                }
            }
            figuraGeometricaAtual = null;
        }

        internal Bitmap RedimensionarFiguraAtual(float zoom, float offsetX, float offsetY, int largura, int altura)
        {
            if (figuraGeometricaAtual == null)
                return new Bitmap(0, 0);

            figuraGeometricaAtual.GerarBitmap(zoom, offsetX, offsetY, largura, altura, Color.White, Color.Black);
            return figuraGeometricaAtual.GetBitmap();
        }

        public void OrdenarFigurasPorArea()
        {
            figurasGeometricas = organizador.OrganizarPorArea(figurasGeometricas);
        }

        public void OrdenarFigurasPorAltura()
        {
            figurasGeometricas = organizador.OrganizarPorAltura(figurasGeometricas);
        }

        public void OrdenarFigurasPorLargura()
        {
            figurasGeometricas = organizador.OrganizarPorLargura(figurasGeometricas);
        }

        public void OrdenarFigurasPorOrdemCustomizada()
        {
            figurasGeometricas = organizador.OrganizarCustomizado(figurasGeometricas);
        }

        internal Bitmap VisualizarFiguraGeometrica(int idFigura)
        {
            foreach (var figura in figurasGeometricas)
            {
                if (figura.id == idFigura)
                {
                    figuraGeometricaAtual = figura;
                }
            }
            return figuraGeometricaAtual.GetBitmap();
        }

        internal Bitmap VisualizarPlanoGeometrico()
        {
            figuraGeometricaAtual = placaGravacao;
            return figuraGeometricaAtual.GetBitmap();
        }

        internal void ExportarResultado(string diretorio)
        {
            DXFExport.Exportar(diretorio, organizador.figurasPosicionadas);
        }
    }
}
