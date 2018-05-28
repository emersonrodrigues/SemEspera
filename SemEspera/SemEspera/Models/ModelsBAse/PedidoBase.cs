using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemEspera.Models
{
    public  class PedidoBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UserId { get; set; }
        public string DataEditada
        { get { return string.Format("{0}/{1}/{2}", DataPedido.Day, DataPedido.Month, DataPedido.Year); } }
        public PedidoBase()
        {

        }
        public PedidoBase(int userId,DateTime dataPedido)
        {
            this.DataPedido = dataPedido;
            this.UserId = UserId;

    }
    }
}
