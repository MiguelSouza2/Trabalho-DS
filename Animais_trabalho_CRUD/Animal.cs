using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;


namespace Animais_trabalho_CRUD 
{
    class Animal : conexao
    {
        private string nome;
        private string especie;
        private string codigo;


        public void setNome(string nome)
        {
            this.nome = nome;
        }
        public string getNome()
        {
            return this.nome;
        }

        public void setEspecie(string especie)
        {
            this.especie = especie;
        }
        public string getEspecie()
        {
            return this.especie;
        }
        public void setCodigo(string codigo)
        {
            this.codigo = codigo;
        }
        public string getCodigo()
        {
            return this.codigo;
        }

        // Método para inserir as informações
        public void inserir()
        {
            string query = "INSERT INTO colaborador(nome_colaborador,sobrenome_colaborador,cpf_colaborador)VALUES('" + getNome() + "','" + getEspecie() + "')";

            if (this.abrirconexao() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharconexao();
            }
        }

        public void excluir()
        {
            string query = "DELETE FROM colaborador WHERE codigo_colaborador = '" + getCodigo() + "'";
            if (this.abrirconexao() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharconexao();
            }

        }

        /*
            Criar um método para consultar
            Colocar biblioteca Using System.Data
        */
        public DataTable Consultar()
        {
            this.abrirconexao();

            string mSQL = "SELECT * FROM colaborador";
            MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            this.fecharconexao();
            // Retornar a consulta SQL em formato de tabela
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

    }
}
