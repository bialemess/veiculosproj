using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace veiculosproj
{
    public partial class AtividadeAvaliativa : Form
    {
        public AtividadeAvaliativa()
        {
            InitializeComponent();
            mkdData.Text = DateTime.Now.ToShortDateString();

            if (DAO_Conexao.getConexao("143.106.241.3", "cl201288", "cl201288", "cl*05062006"))
            {
                Console.WriteLine("Conectado");
                MessageBox.Show("Conectado");
            }
            else
            {
                Console.WriteLine("Erro de conexão");
            }
        }



        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            relogio.Text = DateTime.Now.ToLongTimeString();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void mkdData_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            rdParcelaUnica.Checked = false;
            rdParcelado.Checked = false;

            txtParcela.Text = String.Empty;
            txtValor.Text = String.Empty;
            txtPlaca.Text = String.Empty;
            txtImposto.Text = String.Empty;

        }

        private void txtPlaca_Enter(object sender, EventArgs e)
        {
            txtPlaca.Focus();
        }

        private void mkdData_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                /*txtValor.Focus();*/
            }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(txtValor.Text) * 4;
                double valImp = x / 100;
                txtImposto.Text = "" + valImp;
            }
            catch (Exception x)
            {
                txtImposto.Text = "erro";
            }
        }

        private void rdParcelaUnica_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(txtImposto.Text) * 0.9;
                // double x = (double.Parse(txtImposto.Text) * 25) - (double.Parse(txtImposto.Text) * 2.5);
                txtParcela.Text = "" + x;
            }
            catch (Exception x)
            {
                txtParcela.Text = "erro";
            }
        }

        private void rdParcelado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(txtImposto.Text) / 3;
                txtParcela.Text = "" + x;
            }
            catch (Exception x)
            {
                txtParcela.Text = "erro";
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {  /*
            Veiculos.inserirVeiculo();*/


            int x = 2;
            if (rdParcelado.Checked)
            {
                x = 2;
            }
            else if (rdParcelaUnica.Checked)
            {
                x = 1;  

            }


            Veiculos v = new Veiculos(int.Parse(txtPlaca.Text), (int)float.Parse(rdParcelado.Checked ? txtParcela.Text : txtImposto.Text), float.Parse(txtValor.Text), x);
            v.Pag = x;

            if (v.inserirVeiculo())
            {
                if (x==2)
                {
                    v.AdicionaParcela(0);
                }
                MessageBox.Show("inserido com sucesso");
            }
            else
            {
                MessageBox.Show("erro");
            }
        }


        /*com erro, dor depressão ansiedade

        private void btnPagar_Click(object sender, EventArgs e)
        {

            bool existe = false;
           
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM VEICULO WHERE Veiculo ='" + placa + "'", DAO_Conexao.con);
                MySqlDataReader result = consulta.ExecuteReader();
                if (result.Read())
                {
                    existe = true;

                    MessageBox.Show("Carro existe. placa cadastrada");
                    DAO_Conexao.con.Open();

                    if (txt.ParcelasAPagar>=3){
                    private qntde_parcela_para== txt.ParcelasAPagar ;

                    MySqlCommand command = new MySqlCommand("insert into PAGAMENTO (placa, qtde_parcela_paga) values (" + placa + "," + qtde_parcela_paga + ")", DAO_Conexao.con);
                    try
                    {
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("erro");
                    }

                     else{ MessageBox.Show("o numero de parcelas deve ser menor ou igual a 3");
                     }
                }

                else
                {
                    MessageBox.Show("Carro não existe. placa não cadastrada");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
           
  
                
            }


        
        int placa = int.Parse(txtPlacaConsulta.Text);
        int qtde = int.Parse(txtParcelasAPagar.Text);
        Veiculos v = new Veiculos(placa);
        MySqlDataReader x = v.listarVeiculo();
        String y= null;


        if (x.Read())
        {
            y = x["Placa"].ToString();
        }
        DAO_Conexao.con.Close();
        if (y == null)
        {
            MessageBox.Show("não há nenhum carro com essa placa");
        }*/

        private void label16_Click(object sender, EventArgs e)
        {

        }
        
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Veiculos V = new Veiculos();
            V.Placa = int.Parse(txtPlacaConsultar.Text);
           MySqlDataReader veiculo = V.ListarVeiculo();
            if (!veiculo.Read())
                return;
            
            var forma_pagto = int.Parse(veiculo["forma_pagto"].ToString());
            var valor_imposto = double.Parse(veiculo["valor_imposto"].ToString());
            veiculo.Dispose();
            DAO_Conexao.con.Close();

            if (forma_pagto == 1)
            {
                txtFormaPagmto.Text = "A vista";
                txtValorPago.Text = "  Quitado";
            }
            else
            {
                txtFormaPagmto.Text = "Parcelado";
                if (V.QntdParcela() == 3)
                {
                    txtValorPago.Text = "Quitado";
                }
                else
                {
                    txtValorPago.Text = "" + V.QntdParcela() * valor_imposto;
                }
            }
        }

        private void btnVerifica_Click(object sender, EventArgs e)
        {

            if (int.Parse(txtParcelasAPagar.Text) > 3)
            {
                MessageBox.Show(" Não é possível pagar, parcela superior a 3 ");
                return;
            }

            else if ((int.Parse(txtParcelasAPagar.Text) == 0))
            {
                MessageBox.Show(" Não é possível pagar parcela nula ");
                return;
            }

            Veiculos v = new Veiculos();
            v.Placa = int.Parse(txtPlacaConsulta.Text);
            if (v.VerificaExistencia())
            {
                MessageBox.Show("Veiculo existe");
                if (v.QntdParcela() + int.Parse(txtParcelasAPagar.Text) > 3)
                {

                    MessageBox.Show(" Não é possível pagar, parcela superior a 3 ");
                    return;
                }

                else
                {
                   if(v.PagaParcela(int.Parse(txtParcelasAPagar.Text)))
                    {
                        MessageBox.Show("parcela paga");
                    }
                    else
                    {
                        MessageBox.Show("não foi possível pagar a parcela");
                    }

                }
            }
            else
            {
                MessageBox.Show("Esse veículo não existe");
            }
        }

        private void txtPlacaConsulta_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPlaca.Text = "";
            txtValor.Text = "";
            txtImposto.Text = "";
            rdParcelado.Checked = false;
            rdParcelaUnica.Checked = false;
        }
    }
}
