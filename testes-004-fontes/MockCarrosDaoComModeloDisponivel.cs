using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Benner.Reservas.Entidades;
using Benner.Tecnologia.Common;

namespace Benner.Reservas.Componentes.Teste
{
    public class MockCarrosDaoComModeloDisponivel : ICarrosDao
    {
        public IList<EntityBase> CarrosDisponiveisPorModeloEPeriodo(Handle modelo, DateTime dataInicio, DateTime dataFim)
        {
            var entityBase = new EntityBuilder().AddHandle(1).AddString("IDENTIFICADOR", "Carro Qualquer").Build();

            var result = new List<EntityBase>();
            result.Add(entityBase as EntityBase);
            return result;
        }

        public long CountMany(Expression<Func<ICarros, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public long CountMany(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public ICarros Create()
        {
            throw new NotImplementedException();
        }

        public ICarros Create(NameValueDictionary suggestedValues)
        {
            throw new NotImplementedException();
        }

        public ICarros CreateClone(Handle handle)
        {
            throw new NotImplementedException();
        }

        public ICarros CreateClone(ICarros sourceEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ICarros entity)
        {
            throw new NotImplementedException();
        }

        public SerializableDictionary<Handle, string> DeleteMany(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public SerializableDictionary<Handle, string> DeleteMany(Expression<Func<ICarros, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public SerializableDictionary<Handle, string> DeleteMany(Expression<Func<ICarros, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<ICarros, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<ICarros, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Handle handle)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICarros> FetchMany(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICarros> FetchMany(Expression<Func<ICarros, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICarros> FetchMany(Expression<Func<ICarros, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public ICarros Get(Expression<Func<ICarros, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ICarros Get(Expression<Func<ICarros, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public ICarros Get(Handle handle)
        {
            throw new NotImplementedException();
        }

        public ICarros Get(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public ICarros Get(EntityDefinition entityDefinition, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public ICarros GetFirstOrDefault(Expression<Func<ICarros, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ICarros GetFirstOrDefault(Expression<Func<ICarros, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public ICarros GetFirstOrDefault(Handle handle)
        {
            throw new NotImplementedException();
        }

        public ICarros GetFirstOrDefault(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public ICarros GetForEdit(Expression<Func<ICarros, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public ICarros GetForEdit(Expression<Func<ICarros, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ICarros GetForEdit(Handle handle)
        {
            throw new NotImplementedException();
        }

        public ICarros GetForEdit(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public ICarros GetForEdit(EntityDefinition entityDefinition, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public Handle GetHandle(Expression<Func<ICarros, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Handle GetHandle(Expression<Func<ICarros, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public Handle GetHandle(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IList<ICarros> GetMany(Expression<Func<ICarros, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IList<ICarros> GetMany(Expression<Func<ICarros, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IList<ICarros> GetMany(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public void Save(ICarros entity)
        {
            throw new NotImplementedException();
        }
    }
}