using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModels;
using ValidatieBackend.data;

namespace ValidatieBackend.services
{
    public class AdresService : IAdresService
    {
        private ValidatieContext Db { get; set; }

        public AdresService(ValidatieContext db)
        {
            Db = db;
        }

        public async Task<List<AdresModel>> AdressenLijst()
        {
            var adressen = await Db.Adressen.Select(a => new AdresModel
            {
                Id = a.Id,
                AdresRegel1 = a.AdresRegel1,
                AdresRegel2 = a.AdresRegel2,
                Gemeente = a.Gemeente,
                Huisnummer = a.Huisnummer,
                HuisnummerToevoeging = a.HuisnummerToevoeging,
                Land = a.Land,
                PostCode = a.PostCode,
                Straat = a.Straat
            }).ToListAsync();

            return adressen;
        }

        public async Task<AdresModel> GetAdresById(int id)
        {
            var adres = await Db.Adressen.FindAsync(id);
            if (adres == null) return null;

            return new AdresModel
            {
                Id = adres.Id,
                AdresRegel1 = adres.AdresRegel1,
                AdresRegel2 = adres.AdresRegel2,
                Gemeente = adres.Gemeente,
                Huisnummer = adres.Huisnummer,
                HuisnummerToevoeging = adres.HuisnummerToevoeging,
                Land = adres.Land,
                PostCode = adres.PostCode,
                Straat = adres.Straat
            };
        }

        public async Task<int> CreateAdres(AdresModel model)
        {
            var adres = new Adres
            {
                AdresRegel1 = model.AdresRegel1,
                AdresRegel2 = model.AdresRegel2,
                Gemeente = model.Gemeente,
                Huisnummer = model.Huisnummer,
                HuisnummerToevoeging = model.HuisnummerToevoeging,
                Land = model.Land,
                PostCode = model.PostCode,
                Straat = model.Straat
            };
            Db.Adressen.Add(adres);
            await Db.SaveChangesAsync();

            return adres.Id;
        }

        public async Task<bool> UpdateAdres(AdresModel model)
        {
            var adres = await Db.Adressen.FindAsync(model.Id);
            if (adres == null) return false;

            adres.AdresRegel1 = model.AdresRegel1;
            adres.AdresRegel2 = model.AdresRegel2;
            adres.Gemeente = model.Gemeente;
            adres.Huisnummer = model.Huisnummer;
            adres.HuisnummerToevoeging = model.HuisnummerToevoeging;
            adres.Land = model.Land;
            adres.PostCode = model.PostCode;
            adres.Straat = model.Straat;

            await Db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAdresById(int id)
        {
            var adres = await Db.Adressen.FindAsync(id);
            if (adres == null) return false;

            Db.Adressen.Remove(adres);
            await Db.SaveChangesAsync();

            return true;
        }
    }
}