using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Progresstracker.Configuration;

namespace Progresstracker.Netzwerk
{
    internal partial class TcpSocket : ISocket
    {
        private bool disposedValue;
        private bool _isConnected;
        private readonly ILogger _logger;
        private TcpClient _tcpClient;
        private ConfigurationSettingsHandler _config;

        public bool IsConnected => _isConnected;

        public TcpSocket(ILogger logger, ConfigurationSettingsHandler configuration)
        {
            _logger = logger;
            _tcpClient = new();
            _isConnected = false;
            _config = configuration;
        }

        public void Connect(string address, int port)
        {
            try
            {
                // Überprüfen, ob die Eingabe eine IP-Adresse oder eine URL ist
                IPAddress ipAddress;
                if (IPAddress.TryParse(address, out ipAddress))
                {
                    // Wenn es eine IP-Adresse ist, direkt verbinden
                    _tcpClient.Connect(ipAddress, port);
                }
                else
                {
                    // Wenn es eine URL ist, resolve auf IP-Adresse und verbinden
                    var addresses = Dns.GetHostAddresses(address);
                    if (addresses.Length > 0)
                    {
                        _tcpClient.Connect(addresses[0], port);
                    }
                    else
                    {
                        throw new ArgumentException("Keine gültige Adresse gefunden.");
                    }
                }

                _isConnected = true;
                Console.WriteLine("Verbindung hergestellt zu " + address + ":" + port);
            }
            catch (Exception ex)
            {
                LogConnectionRefused(_logger, ex.Message);
                _isConnected = false;
            }
        }

        public void Disconnect(string portId)
        {
            if (_tcpClient != null && _tcpClient.Connected)
            {
                _tcpClient.Close();
                _isConnected = false;
                Console.WriteLine("Verbindung getrennt.");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: Verwalteten Zustand (verwaltete Objekte) bereinigen
                }

                // TODO: Nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer überschreiben
                // TODO: Große Felder auf NULL setzen
                disposedValue = true;
            }
        }

        // // TODO: Finalizer nur überschreiben, wenn "Dispose(bool disposing)" Code für die Freigabe nicht verwalteter Ressourcen enthält
        // ~TcpSocket()
        // {
        //     // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        [LoggerMessage(Level = LogLevel.Information, Message = "Connection refused: {connectResponse}")]
        static partial void LogConnectionRefused(ILogger logger, string connectResponse);

    }
}
