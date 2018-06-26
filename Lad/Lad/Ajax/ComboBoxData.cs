using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lad.Ajax
{
    public class ComboBoxData
    {
        public List<string> GetCompetition()
        {
            return new List<string>()
                {
                    "Международный",
                    "Российский",
                    "Межрегиональный"
            };

        }
        public List<string> GetStandart()
        {
            return new List<string>()
            {
                "Возрастная группа(6-8лет)",
                "Возрастная группа(9-10лет)",
                "Возрастная группа(11-12лет)",
                "Возрастная группа(13-15лет)",
                "Возрастная группа(16-17лет)",
            };
        }
        public List<string> GetCategory()
        {
            return new List<string>()
            {
                "3-й юношеский",
                "2-й юношеский",
                "1-й юношеский",
                "3-й взрослый",
                "2-й взрослый",
                "1-й взрослый",
                "КМС"
            };
        }

        public List<string> AllType()
        {
            return new List<string>()
            {
                "Соревнования", "Нормативы", "Разряды"
            };
        }
    }
}
