﻿using _01___Model;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Repositorio
{
    public class RepositorioGenerico
    {
        public DocumentStore store { get; set; }

        public RepositorioGenerico()
        {
            store = new DocumentStore
            {
                Url = "http://localhost:8080/",
                DefaultDatabase = "RavenDBCurso"
            };
            store.Initialize();
        }

        public string Cadastrar(Cliente cliente)
        {
            cliente.Id = null;
            return Salvar(cliente);
        }
        public string Atualizar(Cliente cliente)
        {
            return Salvar(cliente);
        }
        public string Salvar(Cliente cliente)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Store(cliente);
                session.SaveChanges();
            }
            return cliente.Id;
        }
        public Cliente Consulte(string idDoClienteSalvo)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                return session.Load<Cliente>(idDoClienteSalvo);
            }
        }

        public void Remover(string idDoClienteSalvo)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Delete(idDoClienteSalvo);
                session.SaveChanges();
            }
        }

        public List<Cliente> Liste()
        {
            using (IDocumentSession session = store.OpenSession())
            {
                return session.Query<Cliente>().ToList();
            }
        }
}
