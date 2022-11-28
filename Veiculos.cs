using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veiculosproj
{
    internal class Veiculos
    {
        private int placa;
        private float imposto;
         private float valor;
         private int pag;

        public Veiculos()
        {
        }

        public Veiculos(int placa)
        {
            this.placa = placa;
        }

        public Veiculos(int placa, float v1, float v2) : this(placa)
        {
        }

        public Veiculos(int placa, float imposto, float valor, int pag)
        {
            this.Placa = placa;
            this.Imposto = imposto;
            this.Valor = valor;
            this.Pag = pag;
        }

        public int Pag { get => pag; set => pag = value; }
        public float Valor { get => valor; set => valor = value; }
        public float Imposto { get => imposto; set => imposto = value; }
        public int Placa { get => placa; set => placa = value; }

        public Boolean inserirVeiculo()
        {
            bool sucesso = false;
            try
            {

                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into VEICULO (Placa, valor_imposto, valor_veiculo, forma_pagto) " +
                    "values ('" + placa + "','" + imposto + "','" + valor + "','" + Pag + "')", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                sucesso = true;

               /* DAO_Conexao.con.Open();
                MySqlCommand query = new MySqlCommand
                    ("insert into VEICULOS (Placa, valor_imposto, valor_veiculo, forma_pagto)" + " values ('" + placa + "','" + imposto + "','" + valor + "','" + Pag + "')",
                     DAO_Conexao.con);
                query.ExecuteNonQuery();
                sucesso = true;*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return sucesso;

        }
        public MySqlDataReader listarVeiculo()
        {
            DAO_Conexao.con.Open();
            MySqlCommand query = new MySqlCommand("select * from VEICULO where placa = "+placa , DAO_Conexao.con);
            return query.ExecuteReader();
     
        }

        public Boolean VerificaExistencia ()
        {

            Boolean resultado = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand query = new MySqlCommand("select * from VEICULO where placa =" + placa, DAO_Conexao.con);
                MySqlDataReader result = query.ExecuteReader();

                if(result.Read())
                {

                    resultado = true;
                    
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return resultado;


        }

        public Boolean AdicionaParcela(int qntParcela)
        {
            bool sucesso = false;
            try
            {

                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into PAGAMENTO (placa, qtde_parcela_paga) " +
                    "values ('"+Placa+"', '" + qntParcela + "')", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                sucesso = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return sucesso;
        }

        public bool PagaParcela(int qtde_parcela_paga)
        {
            bool sucesso = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand update = new MySqlCommand("update PAGAMENTO set qtde_parcela_paga = qtde_parcela_paga + " + qtde_parcela_paga + " where placa =" + Placa, DAO_Conexao.con);
                update.ExecuteNonQuery();
                sucesso = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return sucesso;
        }
        public int QntdParcela()
        {
            int valor=0;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand select = new MySqlCommand("select qtde_parcela_paga from PAGAMENTO where placa=" + placa, DAO_Conexao.con);
                MySqlDataReader parcela = select.ExecuteReader();
                valor = int.Parse(parcela["qtde_parcela_paga"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return valor;
        }
    }
}

