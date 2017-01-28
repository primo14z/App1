using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Database
{
    
        class Stranka
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Priimek { get; set; }
            public string Telefonska { get; set; }
            public string Naslov { get; set; }
            public string Avto { get; set; }
        }

        class Nalog
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Ime_Naloga { get; set; }
            public int Znesek { get; set; }
            public DateTime Datum_Zacetka { get; set; }

            [Indexed]
            public int StrankaId { get; set; }
        }

        class Opravilo
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Ime_Opravila { get; set; }
            public int Znesek { get; set; }
            public int Kolicina { get; set; }

            [Indexed]
            public int NalogId { get; set; }
        }
    
}
