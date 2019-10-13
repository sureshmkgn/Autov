using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autovoice.Common.Mongo
{
    public static class GuidConverter
    {
        /// <summary>
        /// Converts a byte array to a Guid.
        /// </summary>
        /// <param name="bytes">The byte array.</param>
        /// <param name="representation">The representation of the Guid in the byte array.</param>
        /// <returns>A Guid.</returns>
        public static Guid FromBytes(byte[] bytes, GuidRepresentation representation)
        {
            if (bytes.Length != 16)
            {
                var message = string.Format("Length of byte array must be 16, not {0}.", bytes.Length);
                throw new ArgumentException(message);
            }
            bytes = (byte[])bytes.Clone();
            switch (representation)
            {
                case GuidRepresentation.CSharpLegacy:
                    if (!BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(bytes, 0, 4);
                        Array.Reverse(bytes, 4, 2);
                        Array.Reverse(bytes, 6, 2);
                    }
                    break;
                case GuidRepresentation.JavaLegacy:
                    Array.Reverse(bytes, 0, 8);
                    Array.Reverse(bytes, 8, 8);
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(bytes, 0, 4);
                        Array.Reverse(bytes, 4, 2);
                        Array.Reverse(bytes, 6, 2);
                    }
                    break;
                case GuidRepresentation.PythonLegacy:
                case GuidRepresentation.Standard:
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(bytes, 0, 4);
                        Array.Reverse(bytes, 4, 2);
                        Array.Reverse(bytes, 6, 2);
                    }
                    break;
                case GuidRepresentation.Unspecified:
                    throw new InvalidOperationException("Unable to convert byte array to Guid because GuidRepresentation is Unspecified.");
                default:
                    throw new BsonInternalException("Unexpected GuidRepresentation.");
            }
            return new Guid(bytes);
        }

        /// <summary>
        /// Converts a Guid to a byte array.
        /// </summary>
        /// <param name="guid">The Guid.</param>
        /// <param name="guidRepresentation">The representation of the Guid in the byte array.</param>
        /// <returns>A byte array.</returns>
        public static byte[] ToBytes(Guid guid, GuidRepresentation guidRepresentation)
        {
            var bytes = (byte[])guid.ToByteArray().Clone();
            switch (guidRepresentation)
            {
                case GuidRepresentation.CSharpLegacy:
                    if (!BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(bytes, 0, 4);
                        Array.Reverse(bytes, 4, 2);
                        Array.Reverse(bytes, 6, 2);
                    }
                    break;
                case GuidRepresentation.JavaLegacy:
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(bytes, 0, 4);
                        Array.Reverse(bytes, 4, 2);
                        Array.Reverse(bytes, 6, 2);
                    }
                    Array.Reverse(bytes, 0, 8);
                    Array.Reverse(bytes, 8, 8);
                    break;
                case GuidRepresentation.PythonLegacy:
                case GuidRepresentation.Standard:
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(bytes, 0, 4);
                        Array.Reverse(bytes, 4, 2);
                        Array.Reverse(bytes, 6, 2);
                    }
                    break;
                case GuidRepresentation.Unspecified:
                    throw new InvalidOperationException("Unable to convert Guid to byte array because GuidRepresentation is Unspecified.");
                default:
                    throw new ArgumentException($"Invalid guidRepresentation: {guidRepresentation}.", nameof(guidRepresentation));
            }
            return bytes;
        }
    }
}
