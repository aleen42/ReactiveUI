﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Splat;

namespace ReactiveUI
{
    /// <summary>
    /// Helper class used by ReactiveUI to determine the default property in an
    /// implicit binding.
    /// </summary>
    public class DefaultPropertyBinding
    {
        static DefaultPropertyBinding()
        {
            RxApp.EnsureInitialized();
        }

        public static string GetPropertyForControl(object control)
        {
            return Locator.Current.GetServices<IDefaultPropertyBindingProvider>()
                .Select(x => x.GetPropertyForControl(control))
                .Where(x => x != null)
                .OrderByDescending(x => x.Item2)
                .Select(x => x.Item1)
                .FirstOrDefault();
        }
    }
}
