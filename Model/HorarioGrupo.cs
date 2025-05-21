using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    class HorarioGrupo
    {
        private int _Id_HorarioGrupo;
        private int _Id_Grupo;
        private string _DiaSemana;
        private TimeSpan _HoraInicio;
        private TimeSpan _HoraFin;

        public int Id_HorarioGrupo { get => this._Id_HorarioGrupo; set => this._Id_HorarioGrupo = value; }
        public int Id_Grupo { get => this._Id_Grupo; set => this._Id_Grupo = value; }
        public string DiaSemana { get => this._DiaSemana; set => this._DiaSemana = value; }
        public TimeSpan HoraInicio { get => this._HoraInicio; set => this._HoraInicio = value; }
        public TimeSpan HoraFin { get => this._HoraFin; set => this._HoraFin = value; }

    }
}
