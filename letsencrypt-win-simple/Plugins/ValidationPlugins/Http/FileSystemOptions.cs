﻿using PKISharp.WACS.Services;

namespace PKISharp.WACS.Plugins.ValidationPlugins.Http
{
    internal class FileSystemOptions : BaseHttpValidationOptions<FileSystem>
    {
        public override string Name { get => "FileSystem"; }
        public override string Description { get => "Save file on local or network path"; }

        public FileSystemOptions() : base() { }
        public FileSystemOptions(BaseHttpValidationOptions<FileSystem> source) : base(source) { }

        /// <summary>
        /// Alternative site for validation. The path will be
        /// determined from this site on each validation attempt
        /// </summary>
        public long? ValidationSiteId { get; set; }

        /// <summary>
        /// Show to use what has been configured
        /// </summary>
        /// <param name="input"></param>
        public override void Show(IInputService input)
        {
            base.Show(input);
            if (ValidationSiteId != null)
            {
                input.Show("ValidationSite", ValidationSiteId.ToString());
            }
        }
   
    }
}