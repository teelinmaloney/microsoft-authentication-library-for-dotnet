﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Identity.Client.AuthScheme.PoP
{
    // TODO: we can expose this interface to users for a simple but low-level extensibility mechanism.
    // For a more complex extensibility mechanism, we should allow users to configure SigningCredentials, 
    // the top level object exposed by Wilson. Wilson then has adapters for certificates, KeyVault etc.

    /// <summary>
    /// An abstraction over an the asymmetric key operations needed by POP, that encapsulates a pair of 
    /// public and private keys and some typical crypto operations.
    /// All symetric operations are SHA256
    /// </summary>
    /// <remarks>
    /// Important: The 2 methods on this interface will be called at different times but MUST return details of 
    /// the same private / public key pair, i.e. do not change to a different key pair mid way. Best to have this class immutable.
    /// 
    /// Ideally there should be a single public / private key pair associated with a machine, so implementers of this interface
    /// should consider exposing a singleton.
    /// </remarks>
    public interface IPoPCryptoProvider
    {
        /// <summary>
        /// 
        /// </summary>
        RSAParameters PublicKeyInfo { get; private set; }

        /// <summary>
        /// Signs the byte array using the private key
        /// </summary>
        byte[] Sign(byte[] data);
    }
}
