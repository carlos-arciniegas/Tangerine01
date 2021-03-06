﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;
using ExcepcionesTangerine;
using System.Collections;
using ExcepcionesTangerine.M10;

namespace DatosTangerine.DAO.M10
{
    public class DAOEmpleado : DAOGeneral, IDAOEmpleado
    {     
        

        /// <summary>
        /// Metodo para cambiar el estatus de un empleado
        /// </summary>
        /// <param name="empleadoId"></param>
        /// <returns></returns>
        public bool CambiarEstatus(Entidad empleado)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
           
            try
            {

                parameters.Add(new Parametro(ResourceEmpleado.ParamFicha, SqlDbType.VarChar,
                              ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).Id.ToString(), false));

                List<Resultado> results = EjecutarStoredProcedure(ResourceEmpleado.EstatusEmpleado, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ModificarEstatusException("DS-101", "Argumento no valido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new BaseDatosException("DS-101", "Error con la base de datos", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex; 
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }
              

        public bool Modificar(DominioTangerine.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para obtener una tabla Hash con la direccion completa de un empleado 
        /// </summary>
        /// <param name="list">Objeto de tipo Empleado</param>
        /// <returns>Objeto de tipo Hashtable</returns>
        public static Hashtable listElementos(DominioTangerine.Entidades.M10.EmpleadoM10 list)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            Hashtable elementos = new Hashtable();
            try
            {
                foreach (DominioTangerine.Entidades.M10.LugarDireccion elemento in list.ListaDireccion)
                {
                    elementos.Add(elemento.LugTipo, elemento.LugNombre);
                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new BaseDatosException("DS-101", "Error con la base de datos", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return elementos;
        }


        /// <summary>
        /// Metodo para consultar empleados por Id
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public Entidad ConsultarXId(Entidad empleado)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);



            List<Parametro> parameters = new List<Parametro>();
            BDConexion Connection = new BDConexion();
            Parametro param = new Parametro();
            Entidad empleadoFinal;

            try
            {

                
                param = new Parametro("@id", SqlDbType.Int, 
                                     ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_id.ToString(), false);
                parameters.Add(param);

                DataTable dataTable = EjecutarStoredProcedureTuplas(ResourceEmpleado.DetallarEmpleado, parameters);

                DataRow row = dataTable.Rows[0];

                int empId = int.Parse(row[ResourceEmpleado.EmpIdEmpleado].ToString());
                String empPNombre = row[ResourceEmpleado.EmpPNombre].ToString();
                String empSNombre = row[ResourceEmpleado.EmpSNombre].ToString();
                String empPApellido = row[ResourceEmpleado.EmpPApellido].ToString();
                String empSApellido = row[ResourceEmpleado.EmpSApellido].ToString();
                String empGenero = row[ResourceEmpleado.EmpGenero].ToString();
                int empCedula = int.Parse(row[ResourceEmpleado.EmpCedula].ToString());
                DateTime empFecha = DateTime.Parse(row[ResourceEmpleado.EmpFecha].ToString());
                String empActivo = row[ResourceEmpleado.EmpActivo].ToString();
                int empLugId = int.Parse(row[ResourceEmpleado.EmpLugId].ToString());
                String empNivelEstudio = row[ResourceEmpleado.EmpEstudio].ToString();
                String empEmailEmployee = row[ResourceEmpleado.EmpEmail].ToString();

                //Variables que son de la entidad Cargo 
                    String empCargo = row[ResourceEmpleado.EmpCargo].ToString();
                    double empSalario = double.Parse(row[ResourceEmpleado.EmpSueldo].ToString());
                    String empFechaInicio = row[ResourceEmpleado.EmpFechaInicio].ToString();
                    String empFechaFin = row[ResourceEmpleado.EmpFechaFin].ToString();
                    String empDireccion = row[ResourceEmpleado.EmpDireccion].ToString();

                    Entidad cargoEmpleado = DominioTangerine.Fabrica.FabricaEntidades.ObtenerCargoXid(empCargo,
                                            empSalario, empFechaInicio, empFechaFin);

                    empleadoFinal = DominioTangerine.Fabrica.FabricaEntidades.ListarEmpleadoId(empId, empPNombre,
                                                    empSNombre, empPApellido, empSApellido,
                                                    empGenero, empCedula, empFecha, empActivo, empNivelEstudio,
                                                    empEmailEmployee, empLugId, cargoEmpleado, empSalario,
                                                    empFechaInicio, empFechaFin, empDireccion);
    

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ConsultarEmpleadoException("DS-101", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new BaseDatosException("DS-101", "Error con la base de datos", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return empleadoFinal;

        }

    
        /// <summary>
        /// Metodo para consultar todos los empleados
        /// </summary>
        /// <returns></returns>
        public List<DominioTangerine.Entidad> ConsultarTodos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<DominioTangerine.Entidad> listEmpleado = new List<DominioTangerine.Entidad>();

            try
            {
                theConnection.Conectar();
              
                theParam = new Parametro("@param", SqlDbType.Int, "1", false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceEmpleado.ConsultarEmpleado,
                               parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int empId = int.Parse(row[ResourceEmpleado.EmpIdEmpleado].ToString());
                    String empPNombre = row[ResourceEmpleado.EmpPNombre].ToString();
                    String empSNombre = row[ResourceEmpleado.EmpSNombre].ToString();
                    String empPApellido = row[ResourceEmpleado.EmpPApellido].ToString();
                    String empSApellido = row[ResourceEmpleado.EmpSApellido].ToString();
                    int empCedula = int.Parse(row[ResourceEmpleado.EmpCedula].ToString());
                    DateTime empFecha = DateTime.Parse(row[ResourceEmpleado.EmpFecha].ToString());
                    String empActivo = row[ResourceEmpleado.EmpActivo].ToString();
                    String empEmail = row[ResourceEmpleado.EmpEmail].ToString();
                    String empGenero = row[ResourceEmpleado.EmpGenero].ToString();
                    String empEstudio = row[ResourceEmpleado.EmpEstudio].ToString();

                    String empCargo = row[ResourceEmpleado.EmpCargo].ToString();
                    String empCargoDescripcion = row[ResourceEmpleado.EmpCargoDescripcion].ToString();
                    DateTime empContratacion = DateTime.Parse(row[ResourceEmpleado.EmpFechaInicio].ToString());
                    String empModalidad = row[ResourceEmpleado.EmpModalidad].ToString();
                    double empSalario = double.Parse(row[ResourceEmpleado.EmpSueldo].ToString());
                   


                    //Creo un objeto de tipo Entidad con los datos de la fila

                    Entidad cargoEmpleado = DominioTangerine.Fabrica.FabricaEntidades.ObtenerCargo3(empCargo,
                        empCargoDescripcion, empContratacion,empModalidad);
                                            

                    Entidad empleado = DominioTangerine.Fabrica.FabricaEntidades.ConsultarEmpleados
                    (empId, empPNombre, empSNombre,
                     empPApellido, empSApellido, empCedula, empFecha, empActivo, empEmail, empGenero, empEstudio,
                     empModalidad, empSalario, cargoEmpleado);


                    listEmpleado.Add(empleado);
                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ConsultarEmpleadoException("DS-101", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new BaseDatosException("DS-101", "Error con la base de datos", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                     throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listEmpleado;
        }


        /// <summary>
        /// Metodo para consultar los Lugares de tipo Pais dentro de la base de datos
        /// </summary>
        /// <returns>Lista de objetos de tipo LugarDireccion</returns>
        public List<Entidad> ObtenerPaises()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> listPais = new List<Entidad>();

            try
            {
                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro("@tipo", System.Data.SqlDbType.VarChar, "Pais", false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar empleados
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceComplemento.FillSelectCountry, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad pais = DominioTangerine.Fabrica.FabricaEntidades.ObtenerLugar();

                    ((DominioTangerine.Entidades.M10.LugarDireccion)pais).Id = int.Parse(row[ResourceComplemento.
                    ItemCountryValue].ToString());
                    ((DominioTangerine.Entidades.M10.LugarDireccion)pais).LugNombre = (row[ResourceComplemento.
                    ItemCountryText].ToString());

                    listPais.Add(pais);
                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ConsultarEmpleadoException("DS-101", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new BaseDatosException("DS-101", "Error con la base de datos", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listPais;
        }

        
        /// <summary>
        /// Metodo para consultar los Lugares de tipo Estado en la base de datos.
        /// </summary>
        /// <param name="lugarDireccion">Cadena de caracteres que representa el nombre del Pais a filtrar</param>
        /// <returns>Lista de objetos de tipo LugarDireccion</returns>
        public List<Entidad> ObtenerEstados(Entidad lugarDireccion)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> estados = new List<Entidad>();
            List<Parametro> parameters = new List<Parametro>();

            DominioTangerine.Entidades.M10.LugarDireccion param;
            param = (DominioTangerine.Entidades.M10.LugarDireccion)lugarDireccion;
            

            try
            {
                parameters.Add(new Parametro("@lugar", SqlDbType.VarChar, param.LugNombre, false));
                parameters.Add(new Parametro("@tipo", SqlDbType.VarChar, "Estado", false));

                DataTable dt = EjecutarStoredProcedureTuplas(ResourceComplemento.FillSelectState, parameters);                

                foreach (DataRow row in dt.Rows)
                {
                    Entidad Estado=DominioTangerine.Fabrica.FabricaEntidades.ObtenerLugar();

                    ((DominioTangerine.Entidades.M10.LugarDireccion)Estado).Id = int.Parse(row[ResourceComplemento.
                    ItemCountryValue].ToString());
                    ((DominioTangerine.Entidades.M10.LugarDireccion)Estado).LugNombre = (row[ResourceComplemento.
                    ItemCountryText].ToString());                   

                    estados.Add(Estado);
                }
                
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ConsultarEmpleadoException("DS-101", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new BaseDatosException("DS-101", "Error con la base de datos", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return estados;
        }


        /// <summary>
        /// Metodo para traer todos los cargos
        /// </summary>
        /// <returns>Lista de objetos de tipo LugarDireccion</returns>
        public List<Entidad> ObtenerCargos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> listCargo = new List<Entidad>();

            try
            {
                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro("@id", System.Data.SqlDbType.Int, "1", false);
                parameters.Add(theParam);


                //Guardo la tabla que me regresa el procedimiento de consultar cargos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceComplemento.FillSelectJobs, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    
                    Entidad cargo = DominioTangerine.Fabrica.FabricaEntidades.ObtenerCargoM10();

                    ((DominioTangerine.Entidades.M10.CargoM10)cargo).Car_id = int.Parse(row[ResourceComplemento.
                    ItemJobValue].ToString());
                    ((DominioTangerine.Entidades.M10.CargoM10)cargo).Nombre = (row[ResourceComplemento.ItemJobText].
                    ToString());

                    listCargo.Add(cargo);
                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new BaseDatosException("DS-101", "Error con la base de datos", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listCargo;
        }


        /// <summary>
        /// Metodo obtener si un usuario esta activo
        /// </summary>
        /// <returns>Usuario</returns>
        public Entidad ObtenerUsuarioCorreo(Entidad usuario)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);



            List<Parametro> parameters = new List<Parametro>();
            BDConexion Connection = new BDConexion();
            Parametro param = new Parametro();
           

            try
            {

              
                param = new Parametro("@usuario", SqlDbType.VarChar, ((DominioTangerine.Entidades.M2.UsuarioM2)usuario)
                .nombreUsuario.ToString(),false);
                parameters.Add(param);

                param = new Parametro("@correo", SqlDbType.VarChar,((DominioTangerine.Entidades.M2.UsuarioM2)usuario)
                .contrasena.ToString(),false);
                                  
                parameters.Add(param);

              
                DataTable dataTable = EjecutarStoredProcedureTuplas(ResourceEmpleado.ObtenerCorreoUsuario, parameters);

                foreach (DataRow row in dataTable.Rows)
                {
                    string usuAct = row[ResourceEmpleado.UsuActivo].ToString();

                    ((DominioTangerine.Entidades.M2.UsuarioM2)usuario).activo = usuAct;

                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return usuario;


        }


        /// Metodo para agregar un empleado nuevo en la base de datos.
        /// </summary>
        /// <param name="Objeto_Empleado">Objeto de tipo Empleado para agregar en la base de datos</param>
        /// <returns>true si fue agregado</returns>
        public bool Agregar(Entidad elEmpleado)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioTangerine.Entidades.M10.EmpleadoM10 Objeto_Empleado = 
            (DominioTangerine.Entidades.M10.EmpleadoM10)elEmpleado;
            
            List<Parametro> parameters = new List<Parametro>();
            Parametro parametro = new Parametro();
            Hashtable elementos = new Hashtable();
            
            try
            {
                elementos = listElementos(Objeto_Empleado);
                parameters.Add(new Parametro("@pNombre", SqlDbType.VarChar, Objeto_Empleado.Emp_p_nombre, false));
                parameters.Add(new Parametro("@sNombre", SqlDbType.VarChar, Objeto_Empleado.Emp_s_nombre, false));
                parameters.Add(new Parametro("@pApellido", SqlDbType.VarChar, Objeto_Empleado.Emp_p_apellido, false));
                parameters.Add(new Parametro("@sApellido", SqlDbType.VarChar, Objeto_Empleado.Emp_s_apellido, false));
                parameters.Add(new Parametro("@genero", SqlDbType.VarChar, Objeto_Empleado.Emp_genero, false));
                parameters.Add(new Parametro("@cedula", SqlDbType.Int, Objeto_Empleado.Emp_cedula.ToString(), false));
                parameters.Add(new Parametro("@fechaNacimiento", SqlDbType.DateTime, Objeto_Empleado.Emp_fecha_nac.
                ToString("dd/MM/yyyy"), false));
                parameters.Add(new Parametro("@activo", SqlDbType.VarChar, Objeto_Empleado.Emp_activo, false));
                parameters.Add(new Parametro("@nivelEstudio", SqlDbType.VarChar, Objeto_Empleado.Emp_nivel_estudio, false));
                parameters.Add(new Parametro("@correo", SqlDbType.VarChar, Objeto_Empleado.Emp_email, false));
                parameters.Add(new Parametro("@cargo", SqlDbType.VarChar, Objeto_Empleado.jobs.Nombre, false));
                parameters.Add(new Parametro("@fechContrato", SqlDbType.DateTime, Objeto_Empleado.jobs.FechaContratacion.
                ToString("dd/MM/yyyy"), false));
                parameters.Add(new Parametro("@modalidad", SqlDbType.VarChar, Objeto_Empleado.jobs.Modalidad, false));
                parameters.Add(new Parametro("@sueldo", SqlDbType.Int, Objeto_Empleado.jobs.Sueldo.ToString(), false));

                parameters.Add(new Parametro("@estado", SqlDbType.VarChar, elementos["Estado"].ToString(), false));
                parameters.Add(new Parametro("@ciudad", SqlDbType.VarChar, elementos["Ciudad"].ToString(), false));
                parameters.Add(new Parametro("@direccion", SqlDbType.VarChar, elementos["Direccion"].ToString(), false));

                //Se manda a ejecutar el stored procedure
                List<Resultado> resultado = EjecutarStoredProcedure(ResourceEmpleado.AddNewEmpleado, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new AgregarEmpleadoException("DS-101", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new BaseDatosException("DS-101", "Error con la base de datos", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
        
            return true;
        }



    }
    }

