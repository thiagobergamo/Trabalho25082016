using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Financeiro.modelo;
using MySql.Data.MySqlClient;

namespace Financeiro.dao
{
    public class LancamentoDAO
    {
        public void Inserir(Lancamento lancamento)
        {
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connectionInsert = connectionFactory.GetConnection();

            String queryInserir = "INSERT INTO lancamento(data, descricao) values (@data, @descricao)";
            connectionInsert.Open();
            MySqlCommand commandInserir = new MySqlCommand(queryInserir, connectionInsert);
            commandInserir.Prepare();
            commandInserir.Parameters.Add(new MySqlParameter("data", lancamento.data));
            commandInserir.Parameters.Add(new MySqlParameter("descricao", lancamento.descricao));
            commandInserir.ExecuteNonQuery();
            connectionInsert.Close();
        }
        public void Remover(Lancamento lancamento)
        {
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connectionRemover = connectionFactory.GetConnection();

            String query = "DELETE FROM lancamento WHERE idlancamento = @idLancamento";
            connectionRemover.Open();
            MySqlCommand commandRemover = new MySqlCommand(query, connectionRemover);
            commandRemover.Prepare();
            commandRemover.Parameters.Add(new MySqlParameter("idlancamento", lancamento.idLancamento));
            commandRemover.ExecuteNonQuery();
            connectionRemover.Close();
        }
        public void Modificar(Lancamento lancamento)
        {
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connection = connectionFactory.GetConnection();

            String queryModificar = "UPDATE lancamento set data=@data, descricao=@descricao WHERE idlancamento = @idLancamento";
            connection.Open();
            MySqlCommand commandModificar = new MySqlCommand(queryModificar, connection);
            commandModificar.Prepare();
            commandModificar.Parameters.Add(new MySqlParameter("idLancamento", lancamento.idLancamento));
            commandModificar.Parameters.Add(new MySqlParameter("data", lancamento.data));
            commandModificar.Parameters.Add(new MySqlParameter("descricao", lancamento.descricao));
            commandModificar.ExecuteNonQuery();
            connection.Close();
        }
        public Lancamento PesquisarPorId(int idLancamento)
        {
            Lancamento lancamento = new Lancamento();
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connection = connectionFactory.GetConnection();
            String queryPesquisarId = "SELECT idlancamento, data, descricao FROM lancamento WHERE idlancamento = @idLancamento";
            connection.Open();
            MySqlCommand commandPesquisaId = new MySqlCommand(queryPesquisarId, connection);
            commandPesquisaId.Prepare();
            commandPesquisaId.Parameters.Add(new MySqlParameter("idLancamento", idLancamento));
            MySqlDataReader readerPesquisaId = commandPesquisaId.ExecuteReader();
            if (readerPesquisaId.Read())
            {
                lancamento.idLancamento = Convert.ToInt32(readerPesquisaId["idlancamento"]);
                lancamento.data = Convert.ToString(readerPesquisaId["data"]);
                lancamento.descricao = Convert.ToString(readerPesquisaId["descricao"]);
            }
            readerPesquisaId.Close();
            connection.Close();
            return lancamento;
        }
        public List<Lancamento> PesquisarPorData(String data)
        {
            List<Lancamento> lancamentos = new List<Lancamento>();
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connection = connectionFactory.GetConnection();
            String queryPesquisarId = "SELECT idlancamento, data, descricao FROM lancamento WHERE data = @data";
            connection.Open();
            MySqlCommand commandPesquisaId = new MySqlCommand(queryPesquisarId, connection);
            commandPesquisaId.Prepare();
            commandPesquisaId.Parameters.Add(new MySqlParameter("data", data));
            MySqlDataReader readerPesquisaId = commandPesquisaId.ExecuteReader();
            while (readerPesquisaId.Read())
            {
                Lancamento lancamento = new Lancamento();
                lancamento.idLancamento = Convert.ToInt32(readerPesquisaId["idlancamento"]);
                lancamento.data = Convert.ToString(readerPesquisaId["data"]);
                lancamento.descricao = Convert.ToString(readerPesquisaId["descricao"]);
                lancamentos.Add(lancamento);
            }
            readerPesquisaId.Close();
            connection.Close();
            return lancamentos;
        }
        public List<Lancamento> PesquisarTodos()
        {
            List<Lancamento> lancamentos = new List<Lancamento>();
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connection = connectionFactory.GetConnection();
            String queryPesquisarId = "SELECT idlancamento, data, descricao FROM lancamento";
            connection.Open();
            MySqlCommand commandPesquisaId = new MySqlCommand(queryPesquisarId, connection);
            commandPesquisaId.Prepare();
            MySqlDataReader readerPesquisaId = commandPesquisaId.ExecuteReader();
            while (readerPesquisaId.Read())
            {
                Lancamento lancamento = new Lancamento();
                lancamento.idLancamento = Convert.ToInt32(readerPesquisaId["idlancamento"]);
                lancamento.data = Convert.ToString(readerPesquisaId["data"]);
                lancamento.descricao = Convert.ToString(readerPesquisaId["descricao"]);
                lancamentos.Add(lancamento);
            }
            readerPesquisaId.Close();
            connection.Close();
            return lancamentos;

        }
    }
}
