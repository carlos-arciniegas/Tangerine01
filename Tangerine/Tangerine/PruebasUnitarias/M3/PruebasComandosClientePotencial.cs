﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.Comandos.M3;
using LogicaTangerine;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M3;

namespace PruebasUnitarias.M3
{
    [TestFixture]
    public class PruebasComandosClientePotencial
    {
        #region Atributos

        private ClientePotencial elCliente1, elCliente2, elCliente3, elCliente4, elCliente5;
        private Boolean respuesta;
        private List<Entidad> losClientes;
        private LogicaTangerine.Comando<bool> comandoRespuesta;
        private LogicaTangerine.Comando<int> comandoNumero;
        private LogicaTangerine.Comando<Entidad> comandoBuscar;
        private LogicaTangerine.Comando<List<Entidad>> comandoLista;
        private List<Entidad> llamadas, visitas;
        private SeguimientoCliente elSeguimiento;

        #endregion

        #region SetUp y TearDown
        /// <summary>
        /// SetUp para las pruebas de DAOClientePotencial
        /// </summary>
        [SetUp]
        public void init()
        {
            elCliente1 = new DominioTangerine.Entidades.M3.ClientePotencial("Test2", "J-121212-F", "prueba@gmail.com", 121212, 1);
            elCliente2 = new DominioTangerine.Entidades.M3.ClientePotencial();
            elCliente3 = new DominioTangerine.Entidades.M3.ClientePotencial("Test2Cambio", "J-121212-F", "cambio@gmail.com", 746, 1);
            elCliente4 = new DominioTangerine.Entidades.M3.ClientePotencial("Test3", "J-121212-F", "prueba@gmail.com", 121212, 0);
            elCliente5 = new DominioTangerine.Entidades.M3.ClientePotencial();
            elSeguimiento = new SeguimientoCliente(new DateTime(2016, 05, 02), "Llamada", "Prueba de seguimiento", 5);
            losClientes = new List<Entidad>();
            llamadas = new List<Entidad>();
            visitas = new List<Entidad>();
        }

        /// <summary>
        /// TearDown para las pruebas de DAOClientePotencial
        /// </summary>
        [TearDown]
        public void clean()
        {
            elCliente1 = null;
            elCliente2 = null;
            elCliente3 = null;
            elCliente4 = null;
            losClientes = null;
            llamadas = null;
            visitas = null;
        }
        #endregion

        /// <summary>
        /// Método para probar el Comando para agregar un cliente potencial
        /// </summary>
        [Test]
        public void TestComandoAgregarClientePotencial()
        {
            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(elCliente1);
            Assert.IsTrue(comandoRespuesta.Ejecutar());

            comandoNumero = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoUltimoIdClientePotencial();
            elCliente1.Id = comandoNumero.Ejecutar();

            comandoBuscar = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarClientePotencial(elCliente1);
            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)comandoBuscar.Ejecutar();

            Assert.AreEqual(elCliente1.NombreClientePotencial, elCliente2.NombreClientePotencial);
            Assert.AreEqual(elCliente1.RifClientePotencial, elCliente2.RifClientePotencial);
            Assert.AreEqual(elCliente1.EmailClientePotencial, elCliente2.EmailClientePotencial);
            Assert.AreEqual(elCliente1.PresupuestoAnual_inversion, elCliente2.PresupuestoAnual_inversion);

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoEliminarClientePotencial(elCliente1);
            Assert.IsTrue(comandoRespuesta.Ejecutar());
        }

        /// <summary>
        /// Método para probar el Comando para consultar un cliente por ID
        /// </summary>
        [Test]
        public void TestComandoConsultarXIdClientePotencial()
        {
            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(elCliente1);
            comandoRespuesta.Ejecutar();

            comandoNumero = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoUltimoIdClientePotencial();
            elCliente1.Id = comandoNumero.Ejecutar();

            comandoBuscar = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarClientePotencial(elCliente1);
            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)comandoBuscar.Ejecutar();

            Assert.AreEqual(elCliente1.NombreClientePotencial, elCliente2.NombreClientePotencial);
            Assert.AreEqual(elCliente1.RifClientePotencial, elCliente2.RifClientePotencial);
            Assert.AreEqual(elCliente1.EmailClientePotencial, elCliente2.EmailClientePotencial);
            Assert.AreEqual(elCliente1.PresupuestoAnual_inversion, elCliente2.PresupuestoAnual_inversion);

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoEliminarClientePotencial(elCliente1);
            comandoRespuesta.Ejecutar();
        }

        /// <summary>
        /// Método para probar el Comando para activar un cliente por ID
        /// </summary>
        [Test]
        public void TestComandoActivarClientePotencial()
        {
            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(elCliente4);
            comandoRespuesta.Ejecutar();

            comandoNumero = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoUltimoIdClientePotencial();
            elCliente4.Id = comandoNumero.Ejecutar();

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoActivarClientePotencial(elCliente4);
            Assert.IsTrue(comandoRespuesta.Ejecutar());

            comandoBuscar = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarClientePotencial(elCliente4);
            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)comandoBuscar.Ejecutar();

            Assert.AreEqual(elCliente4.NombreClientePotencial, elCliente2.NombreClientePotencial);
            Assert.AreEqual(elCliente4.RifClientePotencial, elCliente2.RifClientePotencial);
            Assert.AreEqual(elCliente4.EmailClientePotencial, elCliente2.EmailClientePotencial);
            Assert.AreEqual(elCliente4.PresupuestoAnual_inversion, elCliente2.PresupuestoAnual_inversion);

            Assert.AreEqual(1,elCliente2.Status);

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoEliminarClientePotencial(elCliente4);
            comandoRespuesta.Ejecutar();
        }

        /// <summary>
        /// Método para probar el Comando para desactivar un cliente por ID
        /// </summary>
        [Test]
        public void TestComandoDesactivarClientePotencial()
        {
            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(elCliente3);
            comandoRespuesta.Ejecutar();

            comandoNumero = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoUltimoIdClientePotencial();
            elCliente3.Id = comandoNumero.Ejecutar();

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoDesactivarClientePotencial(elCliente3);
            Assert.IsTrue(comandoRespuesta.Ejecutar());

            comandoBuscar = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarClientePotencial(elCliente3);
            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)comandoBuscar.Ejecutar();

            Assert.AreEqual(elCliente3.NombreClientePotencial, elCliente2.NombreClientePotencial);
            Assert.AreEqual(elCliente3.RifClientePotencial, elCliente2.RifClientePotencial);
            Assert.AreEqual(elCliente3.EmailClientePotencial, elCliente2.EmailClientePotencial);
            Assert.AreEqual(elCliente3.PresupuestoAnual_inversion, elCliente2.PresupuestoAnual_inversion);

            Assert.AreEqual(0, elCliente2.Status);

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoEliminarClientePotencial(elCliente3);
            comandoRespuesta.Ejecutar();
        }

        /// <summary>
        /// Método para probar el Comando para desactivar un cliente por ID
        /// </summary>
        [Test]
        public void TestComandoEliminarClientePotencial()
        {
            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(elCliente3);
            comandoRespuesta.Ejecutar();

            comandoNumero = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoUltimoIdClientePotencial();
            elCliente3.Id = comandoNumero.Ejecutar();

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoEliminarClientePotencial(elCliente3);
            Assert.IsTrue(comandoRespuesta.Ejecutar());
        }

        /// <summary>
        /// Método para probar el Comando para listar los clientes potenciales
        /// </summary>
        [Test]
        public void TestComandoListarClientePotencial()
        {
            comandoLista = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosClientePotencial();
            losClientes = comandoLista.Ejecutar();
            Assert.NotNull(losClientes);
            foreach (Entidad cliente in losClientes)
            {
                Assert.NotNull(((DominioTangerine.Entidades.M3.ClientePotencial)cliente).EmailClientePotencial);
                Assert.NotNull(((DominioTangerine.Entidades.M3.ClientePotencial)cliente).NombreClientePotencial);
                Assert.NotNull(((DominioTangerine.Entidades.M3.ClientePotencial)cliente).NumeroLlamadas);
                Assert.NotNull(((DominioTangerine.Entidades.M3.ClientePotencial)cliente).NumeroVisitas);
                Assert.NotNull(((DominioTangerine.Entidades.M3.ClientePotencial)cliente).PresupuestoAnual_inversion);
                Assert.NotNull(((DominioTangerine.Entidades.M3.ClientePotencial)cliente).RifClientePotencial);
                Assert.NotNull(((DominioTangerine.Entidades.M3.ClientePotencial)cliente).Status);
                Assert.NotNull(((DominioTangerine.Entidades.M3.ClientePotencial)cliente).IdClientePotencial);
            }
        }

        /// <summary>
        /// Método para probar el Comando para modificar los clientes potenciales
        /// </summary>
        [Test]
        public void TestComandoModificarClientePotencial()
        {
            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(elCliente3);
            Assert.IsTrue(comandoRespuesta.Ejecutar());

            comandoNumero = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoUltimoIdClientePotencial();
            elCliente3.Id = comandoNumero.Ejecutar();

            elCliente3.NombreClientePotencial = "cambio";

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoModificarClientePotencial(elCliente3);
            Assert.IsTrue(comandoRespuesta.Ejecutar());
            elCliente3.Id = comandoNumero.Ejecutar();


            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoEliminarClientePotencial(elCliente3);
            comandoRespuesta.Ejecutar();

        }

        /// <summary>
        /// Método para probar el Comando para promover un cliente por ID
        /// </summary>
        [Test]
        public void TestComandoPromoverClientePotencial()
        {
            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(elCliente3);
            comandoRespuesta.Ejecutar();

            comandoNumero = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoUltimoIdClientePotencial();
            elCliente3.Id = comandoNumero.Ejecutar();

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoPromoverClientePotencial(elCliente3);
            Assert.IsTrue(comandoRespuesta.Ejecutar());

            comandoBuscar = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarClientePotencial(elCliente3);
            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)comandoBuscar.Ejecutar();

            Assert.AreEqual(elCliente3.NombreClientePotencial, elCliente2.NombreClientePotencial);
            Assert.AreEqual(elCliente3.RifClientePotencial, elCliente2.RifClientePotencial);
            Assert.AreEqual(elCliente3.EmailClientePotencial, elCliente2.EmailClientePotencial);
            Assert.AreEqual(elCliente3.PresupuestoAnual_inversion, elCliente2.PresupuestoAnual_inversion);

            Assert.AreEqual(2, elCliente2.Status);

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoEliminarClientePotencial(elCliente3);
            comandoRespuesta.Ejecutar();
        }

        /// <summary>
        /// Método para probar el Comando para listar las llamadas a un cliente potencial
        /// </summary>
        [Test]
        public void TestComandoSeguimientoDeLlamadas()
        {
            elCliente5.Id = 1;
            comandoLista = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarHistoricoLlamadas(elCliente5);
            llamadas = comandoLista.Ejecutar();
            Assert.NotNull(llamadas);
            foreach (Entidad seguimiento in llamadas)
            {
                Assert.NotNull(((SeguimientoCliente)seguimiento).Id);
                Assert.AreEqual("Llamada" ,((SeguimientoCliente)seguimiento).TipoHistoria);
            }
        }

        /// <summary>
        /// Método para probar el Comando para listar las visitas a un cliente potencial
        /// </summary>
        [Test]
        public void TestComandoSeguimientoDeVisitas()
        {
            elCliente5.Id = 1;
            comandoLista = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarHistoricoVisitas(elCliente5);
            visitas = comandoLista.Ejecutar();
            Assert.NotNull(visitas);
            foreach (Entidad seguimiento in visitas)
            {
                Assert.NotNull(((SeguimientoCliente)seguimiento).Id);
                Assert.AreEqual("Visita", ((SeguimientoCliente)seguimiento).TipoHistoria);
            }
        }

        /// <summary>
        /// Método para probar el Comando para agregar un nuevo seguimiento a un cliente potencial
        /// </summary>
        [Test]
        public void TestComandoAgregarSeguimiento()
        {
            bool condicion = false;
            elCliente1.Id = 5;

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarSeguimiento(elSeguimiento);
            Assert.IsTrue(comandoRespuesta.Ejecutar());

            comandoLista = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarHistoricoLlamadas(elCliente1);
            llamadas = comandoLista.Ejecutar();

            Assert.NotNull(llamadas);

            foreach (Entidad seguimiento in llamadas)
            {
                Assert.NotNull(((SeguimientoCliente)seguimiento).Id);
                Assert.AreEqual("Llamada", ((SeguimientoCliente)seguimiento).TipoHistoria);
                if (((SeguimientoCliente)seguimiento).TipoHistoria == elSeguimiento.TipoHistoria &&
                    ((SeguimientoCliente)seguimiento).MotivoHistoria == elSeguimiento.MotivoHistoria &&
                    ((SeguimientoCliente)seguimiento).FkCliente == elSeguimiento.FkCliente)
                {
                    condicion = true;
                }
            }
            Assert.IsTrue(condicion);
        }
    }
}
