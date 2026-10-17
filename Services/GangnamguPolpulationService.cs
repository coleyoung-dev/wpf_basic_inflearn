using System;
using System.Collections.Generic;
using System.Text;
using UiDesktopApp1.Interfaces;
using UiDesktopApp1.Models;

namespace UiDesktopApp1.Services
{
    internal class GangnamguPopulationService : IDatabase<GangnamguPopulation>
    {
        private WpfProjectDatabaseContext _wpfProjectDatabaseContext;
        public GangnamguPopulationService(WpfProjectDatabaseContext wpfProjectDatabaseContext)
        {
            _wpfProjectDatabaseContext = wpfProjectDatabaseContext;
        }
        public void Create(GangnamguPopulation entity)
        {
            _wpfProjectDatabaseContext?.GangnamguPopulations.Add(entity);
            _wpfProjectDatabaseContext?.SaveChanges();
        }
        public void Delete(int? id)
        {
            var validData = _wpfProjectDatabaseContext?.GangnamguPopulations.FirstOrDefault(x => x.Id == id);
            if(validData != null)
            {
                _wpfProjectDatabaseContext?.GangnamguPopulations.Remove(validData);
                _wpfProjectDatabaseContext?.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public List<GangnamguPopulation>? Get()
        {
            return _wpfProjectDatabaseContext.GangnamguPopulations.ToList();
        }

        public GangnamguPopulation? GetDetail(int? id)
        {
            var validData = _wpfProjectDatabaseContext?.GangnamguPopulations.FirstOrDefault(x => x.Id == id);
            if (validData != null)
            {
                return validData;
            }
            else
            {
                MessageBox.Show("해당 데이터가 존재하지 않습니다.", "데이터 조회 오류", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new InvalidOperationException();
                //throw new InvalidOperationException();
            }
        }


        public void Update(GangnamguPopulation entity)
        {
            _wpfProjectDatabaseContext?.GangnamguPopulations.Update(entity);
            _wpfProjectDatabaseContext?.SaveChanges();
        }

    }
}
