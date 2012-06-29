﻿using System.Collections.Generic;
using Highway.Data.Interfaces;

namespace Highway.Data.EntityFramework.Repositories
{
    /// <summary>
    /// A Entity Framework Specific repository implementation that uses Specification pattern to execute Queries in a controlled fashion.
    /// </summary>
    public class EntityFrameworkRepository : IRepository
    {
        /// <summary>
        /// Creates a Repository that uses the context provided
        /// </summary>
        /// <param name="context">The data context that this repository uses</param>
        public EntityFrameworkRepository(IDataContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Reference to the Context the repository is using
        /// </summary>
        public IDataContext Context { get; private set; }
        
        /// <summary>
        /// Reference to the EventManager the repository is using
        /// </summary>
        public IEventManager EventManager { get; private set; }

        /// <summary>
        /// Executes a prebuilt IScalarObject<typeparam name="T"></typeparam> and returns a single instance of <typeparam name="T"></typeparam>
        /// </summary>
        /// <typeparam name="T">The Entity being queried</typeparam>
        /// <param name="query">The prebuilt Query Object</param>
        /// <returns>The instance of <typeparam name="T"></typeparam> returned from the query</returns>
        public T Get<T>(IScalarObject<T> query)
        {
            return query.Execute(Context);
        }
        /// <summary>
        /// Executes a prebuilt ICommandObject
        /// </summary>
        /// <param name="command">The prebuilt command object</param>
        public void Execute(ICommandObject command)
        {
            command.Execute(Context);
        }
        /// <summary>
        /// Executes a prebuilt IQuery<typeparam name="T"></typeparam> and returns an IEnumerable<typeparam name="T"></typeparam>
        /// </summary>
        /// <typeparam name="T">The Entity being queried</typeparam>
        /// <param name="query">The prebuilt Query Object</param>
        /// <returns>The IEnumerable<typeparam name="T"></typeparam> returned from the query</returns>
        public IEnumerable<T> Find<T>(IQuery<T> query) where T : class
        {
            return query.Execute(Context);
        }
    }
}