using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
  public class SerieRepositorio : IRepositorio<Serie>
  {
    private List<Serie> listaSerie = new List<Serie>();
    public void Atualiza(int id, Serie objeto)
    {
        listaSerie[id] = objeto;
    }
    public void Excluir(int id)
    {    
        if(id != null){
            Console.WriteLine("Deseja mesmo excluir esse título do catálogo?");
            Console.WriteLine("yes [Y] | no [N]");
            string op = Console.ReadLine();
            if(op == "Y"){
                listaSerie[id].Excluir();      
            }else{
                return;
            }
        }    
        
    }

    public void Insere(Serie objeto)
    {
        listaSerie.Add(objeto);
    }

    public List<Serie> Lista()
    {
      return listaSerie;
    }

    public int ProximoId()
    {
      return listaSerie.Count;
    }

    public Serie RetornaParId(int id)
    {
      return listaSerie[id];
    }
  }
}