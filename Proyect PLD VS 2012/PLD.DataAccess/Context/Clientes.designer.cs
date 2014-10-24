﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18444
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PLD.DataAccess.Context
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="dbSmartPLD")]
	public partial class ClientesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    #endregion
		
		public ClientesDataContext() : 
				base(global::PLD.DataAccess.Properties.Settings.Default.dbSmartPLDConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ClientesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ClientesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ClientesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ClientesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.stp_getClientes")]
		public ISingleResult<stp_getClientesResult> stp_getClientes([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string vchNoCliente, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(200)")] string vchNombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string vchRFC, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string vchEstado, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string vchMunicipio, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string vhcNoCuenta, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> shRiesgo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> shEstatusSeguimiento)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), vchNoCliente, vchNombre, vchRFC, vchEstado, vchMunicipio, vhcNoCuenta, shRiesgo, shEstatusSeguimiento);
			return ((ISingleResult<stp_getClientesResult>)(result.ReturnValue));
		}
	}
	
	public partial class stp_getClientesResult
	{
		
		private short _shClienteID;
		
		private string _strNoCliente;
		
		private string _strRFC;
		
		private string _strNombre;
		
		private int _shCalificacion;
		
		private int _shRiesgo;
		
		public stp_getClientesResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_shClienteID", DbType="SmallInt NOT NULL")]
		public short shClienteID
		{
			get
			{
				return this._shClienteID;
			}
			set
			{
				if ((this._shClienteID != value))
				{
					this._shClienteID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strNoCliente", DbType="VarChar(20)")]
		public string strNoCliente
		{
			get
			{
				return this._strNoCliente;
			}
			set
			{
				if ((this._strNoCliente != value))
				{
					this._strNoCliente = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strRFC", DbType="VarChar(15)")]
		public string strRFC
		{
			get
			{
				return this._strRFC;
			}
			set
			{
				if ((this._strRFC != value))
				{
					this._strRFC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strNombre", DbType="VarChar(150)")]
		public string strNombre
		{
			get
			{
				return this._strNombre;
			}
			set
			{
				if ((this._strNombre != value))
				{
					this._strNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_shCalificacion", DbType="Int NOT NULL")]
		public int shCalificacion
		{
			get
			{
				return this._shCalificacion;
			}
			set
			{
				if ((this._shCalificacion != value))
				{
					this._shCalificacion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_shRiesgo", DbType="Int NOT NULL")]
		public int shRiesgo
		{
			get
			{
				return this._shRiesgo;
			}
			set
			{
				if ((this._shRiesgo != value))
				{
					this._shRiesgo = value;
				}
			}
		}
	}
}
#pragma warning restore 1591