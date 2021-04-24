﻿using System;
using System.Collections.Generic;

namespace PKISharp.WACS.Configuration.Settings
{
    public class ClientSettings
    {
        public string ClientName { get; set; } = "win-acme";
        public string ConfigurationPath { get; set; } = "";
        public string? LogPath { get; set; }
        public bool VersionCheck { get; set; }
    }

    public class UiSettings
    {
        /// <summary>
        /// The number of hosts to display per page.
        /// </summary>
        public int PageSize { get; set; } = 50;
        /// <summary>
        /// A string that is used to format the date of the 
        /// pfx file friendly name. Documentation for 
        /// possibilities is available from Microsoft.
        /// </summary>
        public string? DateFormat { get; set; }
        /// <summary>
        /// How console tekst should be encoded
        /// </summary>
        public string? TextEncoding { get; set; }
    }

    public class AcmeSettings
    {
        /// <summary>
        /// Default ACMEv2 endpoint to use when none 
        /// is specified with the command line.
        /// </summary>
        public Uri? DefaultBaseUri { get; set; }
        /// <summary>
        /// Default ACMEv2 endpoint to use when none is specified 
        /// with the command line and the --test switch is
        /// activated.
        /// </summary>
        public Uri? DefaultBaseUriTest { get; set; }
        /// <summary>
        /// Default ACMEv1 endpoint to import renewal settings from.
        /// </summary>
        public Uri? DefaultBaseUriImport { get; set; }
        /// <summary>
        /// Use POST-as-GET request mode
        /// </summary>
        public bool PostAsGet { get; set; }
        /// <summary>
        /// Number of times wait for the ACME server to 
        /// handle validation and order processing
        /// </summary>
        public int RetryCount { get; set; } = 4;
        /// <summary>
        /// Amount of time (in seconds) to wait each 
        /// retry for the validation handling and order
        /// processing
        /// </summary>
        public int RetryInterval { get; set; } = 2;
        /// <summary>
        /// If there are alternate certificate, select 
        /// which issuer is preferred
        /// </summary>
        public string? PreferredIssuer { get; set; }
    }

    public class ProxySettings
    {
        /// <summary>
        /// Configures a proxy server to use for 
        /// communication with the ACME server. The 
        /// default setting uses the system proxy.
        /// Passing an empty string will bypass the 
        /// system proxy.
        /// </summary>
        public string? Url { get; set; }
        /// <summary>
        /// Username used to access the proxy server.
        /// </summary>
        public string? Username { get; set; }
        /// <summary>
        /// Password used to access the proxy server.
        /// </summary>
        public string? Password { get; set; }
    }

    /// <summary>
    /// Settings for secret management
    /// </summary>
    public class SecretsSettings
    {
        public JsonSettings? Json { get; set; }
    }

    /// <summary>
    /// Settings for json secret store
    /// </summary>
    public class JsonSettings
    {
        public string? FilePath { get; set; }
    }

    public class CacheSettings
    {
        /// <summary>
        /// The path where certificates and request files are 
        /// stored. If not specified or invalid, this defaults 
        /// to (ConfigurationPath)\Certificates. All directories
        /// and subdirectories in the specified path are created 
        /// unless they already exist. If you are using a 
        /// [[Central SSL Store|Store-Plugins#centralssl]], this
        /// can not be set to the same path.
        /// </summary>
        public string? Path { get; set; }
        /// <summary>
        /// When renewing or re-creating a previously
        /// requested certificate that has the exact 
        /// same set of domain names, the program will 
        /// used a cached version for this many days,
        /// to prevent users from running into rate 
        /// limits while experimenting. Set this to 
        /// a high value if you regularly re-request 
        /// the same certificates, e.g. for a Continuous 
        /// Deployment scenario.
        /// </summary>
        public int ReuseDays { get; set; }
        /// <summary>
        /// Automatically delete files older than 120 days 
        /// from the CertificatePath folder. Running with 
        /// default settings, these should only be long-
        /// expired certificates, generated for abandoned
        /// renewals. However we do advise caution.
        /// </summary>
        public bool DeleteStaleFiles { get; set; }

    }

    public class ScheduledTaskSettings
    {
        /// <summary>
        /// The number of days to renew a certificate 
        /// after. Let’s Encrypt certificates are 
        /// currently for a max of 90 days so it is 
        /// advised to not increase the days much.
        /// If you increase the days, please note
        /// that you will have less time to fix any
        /// issues if the certificate doesn’t renew 
        /// correctly.
        /// </summary>
        public int RenewalDays { get; set; }
        /// <summary>
        /// Configures random time to wait for starting 
        /// the scheduled task.
        /// </summary>
        public TimeSpan RandomDelay { get; set; }
        /// <summary>
        /// Configures start time for the scheduled task.
        /// </summary>
        public TimeSpan StartBoundary { get; set; }
        /// <summary>
        /// Configures time after which the scheduled 
        /// task will be terminated if it hangs for
        /// whatever reason.
        /// </summary>
        public TimeSpan ExecutionTimeLimit { get; set; }
    }

    public class NotificationSettings
    {
        /// <summary>
        /// SMTP server to use for sending email notifications. 
        /// Required to receive renewal failure notifications.
        /// </summary>
        public string? SmtpServer { get; set; }
        /// <summary>
        /// SMTP server port number.
        /// </summary>
        public int SmtpPort { get; set; }
        /// <summary>
        /// User name for the SMTP server, in case 
        /// of authenticated SMTP.
        /// </summary>
        public string? SmtpUser { get; set; }
        /// <summary>
        /// Password for the SMTP server, in case 
        /// of authenticated SMTP.
        /// </summary>
        public string? SmtpPassword { get; set; }
        /// <summary>
        /// Change to True to enable SMTPS.
        /// </summary>
        public bool SmtpSecure { get; set; }
        /// <summary>
        /// 1: Auto (default)
        /// 2: SslOnConnect
        /// 3: StartTls
        /// 4: StartTlsWhenAvailable
        /// </summary>
        public int? SmtpSecureMode { get; set; }
        /// <summary>
        /// Display name to use as the sender of 
        /// notification emails. Defaults to the 
        /// ClientName setting when empty.
        /// </summary>
        public string? SenderName { get; set; }
        /// <summary>
        /// Email address to use as the sender 
        /// of notification emails. Required to 
        /// receive renewal failure notifications.
        /// </summary>
        public string? SenderAddress { get; set; }
        /// <summary>
        /// Email addresses to receive notification emails. 
        /// Required to receive renewal failure 
        /// notifications.
        /// </summary>
        public List<string>? ReceiverAddresses { get; set; }
        /// <summary>
        /// Send an email notification when a certificate 
        /// has been successfully renewed, as opposed to 
        /// the default behavior that only send failure
        /// notifications. Only works if at least 
        /// SmtpServer, SmtpSenderAddressand 
        /// SmtpReceiverAddress have been configured.
        /// </summary>
        public bool EmailOnSuccess { get; set; }
        /// <summary>
        /// Override the computer name that 
        /// is included in the body of the email
        /// </summary>
        public string? ComputerName { get; set; }
    }

    public class SecuritySettings
    {
        /// <summary>
        /// The key size to sign the certificate with. 
        /// Minimum is 2048.
        /// </summary>
        public int RSAKeyBits { get; set; }
        /// <summary>
        /// The curve to use for EC certificates.
        /// </summary>
        public string? ECCurve { get; set; }
        /// <summary>
        /// If set to True, it will be possible to export 
        /// the generated certificates from the certificate 
        /// store, for example to move them to another 
        /// server.
        /// </summary>
        public bool PrivateKeyExportable { get; set; }
        /// <summary>
        /// Uses Microsoft Data Protection API to encrypt 
        /// sensitive parts of the configuration, e.g. 
        /// passwords. This may be disabled to share 
        /// the configuration across a cluster of machines.
        /// </summary>
        public bool EncryptConfig { get; set; }
    }

    /// <summary>
    /// Options for installation and DNS scripts
    /// </summary>
    public class ScriptSettings
    {
        public int Timeout { get; set; } = 600;
    }

    public class TargetSettings
    {
        /// <summary>
        /// Default plugin to select in the Advanced menu
        /// in the menu.
        public string? DefaultTarget { get; set; }
    }

    public class ValidationSettings
    {
        /// <summary>
        /// Default plugin to select in the Advanced menu (if
        /// supported for the target), or when nothing is 
        /// specified on the command line.
        /// </summary>
        public string? DefaultValidation { get; set; }

        /// <summary>
        /// Default plugin type, e.g. HTTP-01 (default), DNS-01, etc.
        /// </summary>
        public string? DefaultValidationMode { get; set; }

        /// <summary>
        /// Disable multithreading for validation
        /// </summary>
        public bool? DisableMultiThreading { get; set; }

        /// <summary>
        /// If set to True, it will cleanup the folder structure
        /// and files it creates under the site for authorization.
        /// </summary>
        public bool CleanupFolders { get; set; }
        /// <summary>
        /// If set to `true`, it will wait until it can verify that the 
        /// validation record has been created and is available before 
        /// beginning DNS validation.
        /// </summary>
        public bool PreValidateDns { get; set; } = true;
        /// <summary>
        /// Maximum numbers of times to retry DNS pre-validation, while
        /// waiting for the name servers to start providing the expected
        /// answer.
        /// </summary>
        public int PreValidateDnsRetryCount { get; set; } = 5;
        /// <summary>
        /// Amount of time in seconds to wait between each retry.
        /// </summary>
        public int PreValidateDnsRetryInterval { get; set; } = 30;
        /// <summary>
        /// If set to `true`, the program will attempt to recurively 
        /// follow CNAME records present on _acme-challenge subdomains to 
        /// find the final domain the DNS-01 challenge should be handled by.
        /// This allows you to delegate validation of your certificates
        /// to another domain or provider, which can have benefits for 
        /// security or save you the effort of having to move everything 
        /// to a party that supports automation.
        /// </summary>
        public bool AllowDnsSubstitution { get; set; } = true;
        /// <summary>
        /// A comma-separated list of servers to query during DNS 
        /// prevalidation checks to verify whether or not the validation 
        /// record has been properly created and is visible for the world.
        /// These servers will be used to located the actual authoritative 
        /// name servers for the domain. You can use the string [System] to
        /// have the program query your servers default, but note that this 
        /// can lead to prevalidation failures when your Active Directory is 
        /// hosting a private version of the DNS zone for internal use.
        /// </summary>
        public List<string>? DnsServers { get; set; }
    }

    public class OrderSettings
    {
        /// <summary>
        /// Default plugin to select when none is provided through the 
        /// command line
        /// </summary>
        public string? DefaultPlugin { get; set; }
    }

    public class CsrSettings
    {
        /// <summary>
        /// Default plugin to select 
        /// </summary>
        public string? DefaultCsr { get; set; }
    }

    public class StoreSettings
    {
        /// <summary>
        /// Default plugin(s) to select 
        /// </summary>
        public string? DefaultStore { get; set; }

        [Obsolete]
        public string? DefaultCertificateStore { get; set; }
        [Obsolete]
        public string? DefaultCentralSslStore { get; set; }
        [Obsolete]
        public string? DefaultCentralSslPfxPassword { get; set; }
        [Obsolete]
        public string? DefaultPemFilesPath { get; set; }

        /// <summary>
        /// Settings for the CentralSsl plugin
        /// </summary>
        public CertificateStoreSettings? CertificateStore { get; set; }

        /// <summary>
        /// Settings for the CentralSsl plugin
        /// </summary>
        public CentralSslSettings? CentralSsl { get; set; }

        /// <summary>
        /// Settings for the PemFiles plugin
        /// </summary>
        public PemFilesSettings? PemFiles { get; set; }

        /// <summary>
        /// Settings for the PfxFile plugin
        /// </summary>
        public PfxFileSettings? PfxFile { get; set; }

    }

    public class CertificateStoreSettings
    {
        /// <summary>
        /// The certificate store to save the certificates in. If left empty, 
        /// certificates will be installed either in the WebHosting store, 
        /// or if that is not available, the My store (better known as Personal).
        /// </summary>
        public string? DefaultStore { get; set; }
    }

    public class PemFilesSettings
    {
        /// <summary>
        /// When using --store pemfiles this path is used by default, saving 
        /// you the effort from providing it manually. Filling this out makes 
        /// the --pemfilespath parameter unnecessary in most cases. Renewals 
        /// created with the default path will automatically change to any 
        /// future default value, meaning this is also a good practice for 
        /// maintainability.
        /// </summary>
        public string? DefaultPath { get; set; }
        /// <summary>
        /// When using --store pemfiles this password is used by default for 
        /// the private key file, saving you the effort from providing it manually. 
        /// Filling this out makes the --pemfilespassword parameter unnecessary in 
        /// most cases. Renewals created with the default password will 
        /// automatically change to any future default value, meaning this
        /// is also a good practice for maintainability.
        /// </summary>
        public string? DefaultPassword { get; set; }
    }
    public class CentralSslSettings
    {
        /// <summary>
        /// When using --store centralssl this path is used by default, saving you
        /// the effort from providing it manually. Filling this out makes the 
        /// --centralsslstore parameter unnecessary in most cases. Renewals 
        /// created with the default path will automatically change to any 
        /// future default value, meaning this is also a good practice for 
        /// maintainability.
        /// </summary>
        public string? DefaultPath { get; set; }
        /// <summary>
        /// When using --store centralssl this password is used by default for 
        /// the pfx files, saving you the effort from providing it manually. 
        /// Filling this out makes the --pfxpassword parameter unnecessary in 
        /// most cases. Renewals created with the default password will 
        /// automatically change to any future default value, meaning this
        /// is also a good practice for maintainability.
        /// </summary>
        public string? DefaultPassword { get; set; }
    }

    public class PfxFileSettings
    {
        /// <summary>
        /// When using --store pfxfile this path is used by default, saving 
        /// you the effort from providing it manually. Filling this out makes 
        /// the --pfxfilepath parameter unnecessary in most cases. Renewals 
        /// created with the default path will automatically change to any 
        /// future default value, meaning this is also a good practice for 
        /// maintainability.
        /// </summary>
        public string? DefaultPath { get; set; }
        /// <summary>
        /// When using --store pfxfile this password is used by default for 
        /// the pfx files, saving you the effort from providing it manually. 
        /// Filling this out makes the --pfxpassword parameter unnecessary in 
        /// most cases. Renewals created with the default password will 
        /// automatically change to any future default value, meaning this
        /// is also a good practice for maintainability.
        /// </summary>
        public string? DefaultPassword { get; set; }
    }

    public class InstallationSettings
    {
        /// <summary>
        /// Default plugin(s) to select 
        /// </summary>
        public string? DefaultInstallation { get; set; }
    }
}