using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Benner.Reservas.Entidades;
using Benner.Tecnologia.Common;

namespace Benner.Reservas.Componentes.Teste
{
    public class MockReservasDaoComSaveGet : IReservasDao
    {
        private IReservas _reserva;

        public long CountMany(Expression<Func<IReservas, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public long CountMany(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IReservas Create()
        {
            throw new NotImplementedException();
        }

        public IReservas Create(NameValueDictionary suggestedValues)
        {
            throw new NotImplementedException();
        }

        public IReservas CreateClone(Handle handle)
        {
            throw new NotImplementedException();
        }

        public IReservas CreateClone(IReservas sourceEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IReservas entity)
        {
            throw new NotImplementedException();
        }

        public SerializableDictionary<Handle, string> DeleteMany(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public SerializableDictionary<Handle, string> DeleteMany(Expression<Func<IReservas, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public SerializableDictionary<Handle, string> DeleteMany(Expression<Func<IReservas, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public bool ExisteReservaAgora(Handle carro)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<IReservas, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<IReservas, bool>> expression, Criteria criteria)
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

        public IEnumerable<IReservas> FetchMany(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IReservas> FetchMany(Expression<Func<IReservas, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IReservas> FetchMany(Expression<Func<IReservas, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IReservas Get(Expression<Func<IReservas, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IReservas Get(Expression<Func<IReservas, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IReservas Get(Handle handle)
        {
            return _reserva;
        }

        public IReservas Get(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IReservas Get(EntityDefinition entityDefinition, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IReservas GetFirstOrDefault(Expression<Func<IReservas, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IReservas GetFirstOrDefault(Expression<Func<IReservas, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IReservas GetFirstOrDefault(Handle handle)
        {
            throw new NotImplementedException();
        }

        public IReservas GetFirstOrDefault(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IReservas GetForEdit(Expression<Func<IReservas, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IReservas GetForEdit(Expression<Func<IReservas, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IReservas GetForEdit(Handle handle)
        {
            throw new NotImplementedException();
        }

        public IReservas GetForEdit(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IReservas GetForEdit(EntityDefinition entityDefinition, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public Handle GetHandle(Expression<Func<IReservas, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Handle GetHandle(Expression<Func<IReservas, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public Handle GetHandle(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IList<IReservas> GetMany(Expression<Func<IReservas, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IList<IReservas> GetMany(Expression<Func<IReservas, bool>> expression, Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IList<IReservas> GetMany(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public IList<IReservas> ReservasPorStatusEspecifico(int status)
        {
            throw new NotImplementedException();
        }

        public IList<IReservas> ReservasPorStatusEspecifico(int status, DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        public void Save(IReservas entity)
        {
            _reserva = entity;
        }
    }
}