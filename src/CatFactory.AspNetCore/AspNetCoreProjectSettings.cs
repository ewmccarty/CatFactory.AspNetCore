﻿namespace CatFactory.AspNetCore
{
    public class AspNetCoreProjectSettings : ProjectSettings
    {
        public string ProjectName { get; set; }

        public string OutputDirectory { get; set; }

        public bool UseLogger { get; set; } = true;
    }
}
