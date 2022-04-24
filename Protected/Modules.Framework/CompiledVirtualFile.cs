﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Modules.Framework
{
    public class CompiledVirtualFile : VirtualFile
    {
        public CompiledVirtualFile(string virtualPath, Type compiledType)
            : base(virtualPath)
        {
            CompiledType = compiledType;
        }
        public Type CompiledType { get; set; }
        public CompiledVirtualFile Type { get; set; }
        /// <summary>
        /// When overridden in a derived class, returns a read-only stream to the virtual resource.
        /// </summary>
        /// <returns>
        /// A read-only stream to the virtual file.
        /// </returns>
        public override Stream Open()
        {
            return Stream.Null;
        }
    }
}