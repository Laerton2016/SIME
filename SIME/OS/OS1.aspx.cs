using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIME.Class;
using Sime;
using System.Drawing;
using Ean13Barcode2005;


namespace SIME.OS
{
    public partial class OS1 : System.Web.UI.Page
    {
        protected Aparelho aparelho_OS;
        private String N_OS ;
        private Cliente clienteOS;
        private Ean13 ean13;
        protected void Page_Load(object sender, EventArgs e)
        {
            N_OS = Request.QueryString["OS"];
            aparelho_OS = new Class.Aparelho(Convert.ToInt32(N_OS));
            clienteOS = new Cliente(aparelho_OS.IDcliente, new Conexao().getDb4());
            preencheDados();
            
        }

        private void preencheDados() {
            String funcionario = "";
            lab_nome.Text = clienteOS.getNome();
            Lab_doc.Text = clienteOS.getCPFCNPJ();
            lab_nome0.Text = "<b>OS: </b>" + aparelho_OS.getID() + " " + lab_nome.Text;
            Lab_doc0.Text = Lab_doc.Text;
            Lab_assina.Text = "____________________________________________ <br> " + clienteOS.getNome() + "<br>" + "CPF/CNPJ:" + clienteOS.getCPFCNPJ();
            Lab_aparelho.Text = new TiposAparelhos().getTipo(aparelho_OS.IDTipoAparelho);
            Lab_marca.Text = new Marcas().getTipo(aparelho_OS.IDMarca);
            Lab_modelo.Text = aparelho_OS.Modelo;
            Lab_garantia.Text = (aparelho_OS.Garantia)? "SIM": "NÃO";
            Lab_loja.Text = new loja(aparelho_OS.IDloja).getRazao();
            Lab_NF.Text = (aparelho_OS.Garantia)? aparelho_OS.Nf + " <b>Data: </b>" + aparelho_OS.DataNF.ToShortDateString() + " <b>N° Série: </b>" + aparelho_OS.Serie : "Produto fora de garantia" ;
            if (aparelho_OS.IDOPRecebedor != 0)
            {
                funcionario = new Usuarios(new Conexao().getContas()).buscaUsuario(aparelho_OS.IDOPRecebedor).getNome();
            }
            Lab_aparelho0.Text = new TiposAparelhos().getTipo(aparelho_OS.IDTipoAparelho);
            Lab_marca0.Text = new Marcas().getTipo(aparelho_OS.IDMarca);
            Lab_modelo0.Text = aparelho_OS.Modelo;
            Lab_garantia0.Text = (aparelho_OS.Garantia) ? "SIM" : "NÃO";
            Lab_resumo.Text = "Caro cliente, segundo CDC art. 18 §2 a empresa terá até 30 dias para diagnosticar o equipamento, em caso de troca de componente poderá prorrogar em até mais 30 dias. <br>" +
                "Fica facultado a esta empresa a cobrança de uma taxa de R$ 20,00 (Vinte reais) em caso de desistência do cliente da conclusão do serviço, para cobrança de hora trabalho do técnico no diagnóstico. <br>" +
                "A empresa poderá cobrar taxa de locação de espaço após 30(trinta) dias do contato realizado seja por telefone, SMS, e-mail ou carta. Podendo ser considerado abandono do bem caso este prazo chegue a ultrapassar 1 ano ficando o equipamento disponível para doação.<br>" +
                "Ao assinar este documento o cliente concorda com os termos acima ciente que leu e entendeu todos os seus termos.";
            Lab_texto.Text = Lab_resumo.Text;
            Lab_dadosOS.Text = "N° OS: <b>" + aparelho_OS.getID() + "</b> " + " Data abertura: " + aparelho_OS.DtAberturaOS.ToShortDateString() 
                + "<br><b>Funcionário: </b>" + funcionario;

            Lab_acessorios.Text = aparelho_OS.informeAcessorios();
            Lab_Defeito.Text = aparelho_OS.Defeito;
            montaGrafico();
        }
        private void CreateEan13()
        {
            ean13 = new Ean13();
            ean13.CountryCode = "00";
            ean13.ManufacturerCode = "00000";
            ean13.ProductCode = Convert.ToString( aparelho_OS.getID());
            ean13.ChecksumDigit = "0";
        }

        private void montaGrafico() {
         
            img1.Width = 40;
            img1.Height = 35;
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img1.Width *6, img1.Height *6);

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);

            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White),
                new Rectangle(0, 0, bmp.Width, bmp.Height));

            CreateEan13();
            ean13.Scale = 1.5F;
            ean13.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
            g.Dispose();

            bmp.Save(Server.MapPath("~/Imagens/cod.bmp"));
            img1.Src = "~/Imagens/cod.bmp";
            img2.Src = img3.Src = img4.Src = img1.Src;
        }
    }
}