using System;

namespace NCrunch.Framework
{
    public class DistributeByCapabilitiesAttribute: Attribute
    {
        private string[] _capabilities;

        public DistributeByCapabilitiesAttribute(params string[] capabilities)
        {
            _capabilities = capabilities;
        }

        public string[] Capabilities
        {
            get { return _capabilities; }
        }
    }
}
