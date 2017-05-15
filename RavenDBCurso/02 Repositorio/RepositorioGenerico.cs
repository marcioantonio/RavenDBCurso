using Model;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio
{
    public class RepositorioGenerico
    {
        public DocumentStore store { get; set; }

        public RepositorioGenerico()
        {
            store = new DocumentStore
            {
                Url = "http//localhost:8080",
                DefaultDatabase = "RavenDBCurso"
            };
            store.Initialize();
        }

        public void Cadastrar(Cliente cliente)
        {
            using(IDocumentSession session = store.OpenSession())
            {
                session.Store(cliente);
                session.SaveChanges();
            }
        }


    }
}
