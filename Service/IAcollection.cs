using BlazorApp1.Models;

namespace BlazorApp1.Service
{
    public interface IAcollection
    {
      public Task<ModeloParaRespuesta> consultaPost(ModeloConsulta objetoConsulta);
    //    public Task<ModeloParaPost> paraPost(string data);
    }
}
