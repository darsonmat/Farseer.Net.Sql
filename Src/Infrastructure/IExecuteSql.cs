﻿using System.Data;
using FS.Sql.Data;
using FS.Sql.Internal;

namespace FS.Sql.Infrastructure
{
    /// <summary> 将SQL发送到数据库 </summary>
    internal interface IExecuteSql
    {
        /// <summary>
        ///     数据库操作
        /// </summary>
        DbExecutor DataBase { get; }

        /// <summary>
        ///     返回影响行数
        /// </summary>
        /// <param name="sqlParam">SQL语句与参数</param>
        int Execute(ISqlParam sqlParam);

        /// <summary>
        ///     返回影响行数
        /// </summary>
        /// <typeparam name="TEntity">实体类</typeparam>
        /// <param name="procBuilder">SQL语句与参数</param>
        /// <param name="entity">实体类</param>
        int Execute<TEntity>(ProcBuilder procBuilder, TEntity entity) where TEntity : class, new();

        /// <summary>
        ///     返回DataTable
        /// </summary>
        /// <param name="sqlParam">SQL语句与参数</param>
        DataTable ToTable(ISqlParam sqlParam);

        /// <summary>
        ///     返回DataTable
        /// </summary>
        /// <typeparam name="TEntity">实体类</typeparam>
        /// <param name="procBuilder">SQL语句与参数</param>
        /// <param name="entity">实体类</param>
        DataTable ToTable<TEntity>(ProcBuilder procBuilder, TEntity entity) where TEntity : class, new();

        /// <summary>
        ///     返回单条数据
        /// </summary>
        /// <typeparam name="TEntity">实体类</typeparam>
        /// <param name="sqlParam">SQL语句与参数</param>
        TEntity ToEntity<TEntity>(ISqlParam sqlParam) where TEntity : class, new();

        /// <summary>
        ///     返回单条数据
        /// </summary>
        /// <typeparam name="TEntity">实体类</typeparam>
        /// <param name="procBuilder">SQL语句与参数</param>
        /// <param name="entity">实体类</param>
        TEntity ToEntity<TEntity>(ProcBuilder procBuilder, TEntity entity) where TEntity : class, new();

        /// <summary>
        ///     查询单个字段值
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="sqlParam">SQL语句与参数</param>
        /// <param name="defValue">默认值</param>
        T GetValue<T>(ISqlParam sqlParam, T defValue = default(T));

        /// <summary>
        ///     查询单个字段值
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <typeparam name="TEntity">实体类</typeparam>
        /// <param name="procBuilder">SQL语句与参数</param>
        /// <param name="entity">实体类</param>
        /// <param name="defValue">默认值</param>
        T GetValue<TEntity, T>(ProcBuilder procBuilder, TEntity entity, T defValue = default(T)) where TEntity : class, new();
    }
}