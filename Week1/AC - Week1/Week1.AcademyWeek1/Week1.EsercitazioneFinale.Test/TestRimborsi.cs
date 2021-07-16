using System;
using System.Collections.Generic;
using Week1.EsercitazioneFinale.Entities;
using Week1.EsercitazioneFinale.Factory;
using Xunit;

namespace Week1.EsercitazioneFinale.Test
{
    public class TestRimborsi
    {
        public static List<Spesa> GetSpese()
        {
            FactoryCategoria factory = new FactoryCategoria();
            var spese = new List<Spesa>()
            {
                new Spesa(){
                    Data = new DateTime(2020,10,30,14,30,12),
                    Categoria =factory.GetCategoria("Viaggio"),
                    Descrizione="viaggio alle maldive",
                    Importo=500
                },
                new Spesa(){
                    Data = new DateTime(2020,10,30,14,30,12),
                    Categoria =factory.GetCategoria("Viaggio"),
                    Descrizione="viaggio alle maldive parte due",
                    Importo=3100
                },
                new Spesa(){
                    Data = new DateTime(2020,10,30,14,30,12),
                    Categoria =factory.GetCategoria("Vitto"),
                    Descrizione="Pizza Gourmet",
                    Importo=1400
                },
                new Spesa(){
                    Data = new DateTime(2020,10,30,14,30,12),
                    Categoria =factory.GetCategoria("Altro"),
                    Descrizione="Gomma",
                    Importo=50
                },
                new Spesa(){
                    Data = new DateTime(2020,10,30,14,30,12),
                    Categoria =factory.GetCategoria("Alloggio"),
                    Descrizione="Albergo",
                    Importo=350
                }

            };
            return spese;
        }
        [Fact]
        public void TestApprovazioneSpesa()
        {
            //Preparazione Dati iniziali
            var spese = GetSpese();

            //Metodo
            List<Rimborso> rimborsi = Rimborso.ElaborazioneRimborsi(spese);

            //Verifica
            Assert.Equal("Viaggio", rimborsi[0].Spesa.Categoria.Nome);
            Assert.Equal(550, rimborsi[0].ImportoRimborsato);
            Assert.True(rimborsi[0].Approvato);
            Assert.Equal("OPManager", rimborsi[0].LivelloApprovazione);
        }

        [Fact]
        public void TestApprovazioneSpesa1()
        {
            //Preparazione Dati iniziali
            var spese = GetSpese();

            //Metodo
            List<Rimborso> rimborsi = Rimborso.ElaborazioneRimborsi(spese);

            //Verifica
            Assert.Equal("Viaggio", rimborsi[1].Spesa.Categoria.Nome);
            Assert.Equal(0, rimborsi[1].ImportoRimborsato);
            Assert.False(rimborsi[1].Approvato);
            Assert.Equal("", rimborsi[1].LivelloApprovazione);
        }

        [Fact]
        public void TestApprovazioneSpesa2()
        {
            //Preparazione Dati iniziali
            var spese = GetSpese();

            //Metodo
            List<Rimborso> rimborsi = Rimborso.ElaborazioneRimborsi(spese);

            //Verifica
            Assert.Equal("Vitto", rimborsi[2].Spesa.Categoria.Nome);
            Assert.Equal(979, 9999999999999, rimborsi[2].ImportoRimborsato);
            Assert.True(rimborsi[2].Approvato);
            Assert.Equal("CEO", rimborsi[2].LivelloApprovazione);
        }

        [Fact]
        public void TestApprovazioneSpesa4()
        {
            //Preparazione Dati iniziali
            var spese = GetSpese();

            //Metodo
            List<Rimborso> rimborsi = Rimborso.ElaborazioneRimborsi(spese);

            //Verifica
            Assert.Equal("Altro", rimborsi[3].Spesa.Categoria.Nome);
            Assert.Equal(5, rimborsi[3].ImportoRimborsato);
            Assert.True(rimborsi[3].Approvato);
            Assert.Equal("Manager", rimborsi[3].LivelloApprovazione);
        }

        [Fact]
        public void TestApprovazioneSpesa5()
        {
            //Preparazione Dati iniziali
            var spese = GetSpese();

            //Metodo
            List<Rimborso> rimborsi = Rimborso.ElaborazioneRimborsi(spese);

            //Verifica
            Assert.Equal("Alloggio", rimborsi[4].Spesa.Categoria.Nome);
            Assert.Equal(350, rimborsi[4].ImportoRimborsato);
            Assert.True(rimborsi[4].Approvato);
            Assert.Equal("Manager", rimborsi[4].LivelloApprovazione);
        }
    }
}
