﻿using infolimpiadas.Domain.Entity;

namespace infolimpiadas.Domain.Repository
{
    public interface IAtletaRepository
    {
        Task<Atleta> GetAtleta(int id);
        Atleta Save(Atleta atleta);
        Task<List<Atleta>> GetAll();
        void Update(Atleta atleta);
    }
}
