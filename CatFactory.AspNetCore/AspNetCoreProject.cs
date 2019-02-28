﻿using System.Diagnostics;
using System.Linq;
using CatFactory.CodeFactory.Scaffolding;
using CatFactory.EntityFrameworkCore;
using CatFactory.NetCore;
using CatFactory.ObjectRelationalMapping;
using Microsoft.Extensions.Logging;

namespace CatFactory.AspNetCore
{
    public class AspNetCoreProject : CSharpProject<AspNetCoreProjectSettings>
    {
        public AspNetCoreProject()
            : base()
        {
        }

        public AspNetCoreProject(ILogger<AspNetCoreProject> logger)
            : base(logger)
        {
        }

        public string Version { get; set; }

        public EntityFrameworkCoreProject EntityFrameworkCoreProject { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AspNetCoreProjectNamespaces m_aspNetCoreProjectNamespaces;

        public AspNetCoreProjectNamespaces AspNetCoreProjectNamespaces
        {
            get
            {
                return m_aspNetCoreProjectNamespaces ?? (m_aspNetCoreProjectNamespaces = new AspNetCoreProjectNamespaces());
            }
            set
            {
                m_aspNetCoreProjectNamespaces = value;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EntityFrameworkCoreProjectNamespaces m_projectNamespaces;

        public EntityFrameworkCoreProjectNamespaces EntityFrameworkCoreProjectNamespaces
        {
            get
            {
                return m_projectNamespaces ?? (m_projectNamespaces = new EntityFrameworkCoreProjectNamespaces());
            }
            set
            {
                m_projectNamespaces = value;
            }
        }

        public override void BuildFeatures()
        {
            if (Database == null)
                return;

            Features = Database
                .DbObjects
                .Select(item => item.Schema)
                .Distinct()
                .Select(item => new ProjectFeature<AspNetCoreProjectSettings>(item, GetDbObjectsBySchema(item), this))
                .ToList();
        }
    }
}
