﻿// ReSharper disable InconsistentNaming

namespace AdoNetCore.AseClient.Enum
{
    internal enum MessageIdentifier : ushort
    {
        /// <summary>
        /// Start encrypted login protocol.
        /// </summary>
        TDS_MSG_SEC_ENCRYPT = 1,
        /// <summary>
        /// Sending encrypted user password.
        /// </summary>
        TDS_MSG_SEC_LOGPWD = 2,
        /// <summary>
        /// Sending remote server passwords.
        /// </summary>
        TDS_MSG_SEC_REMPWD = 3,
        /// <summary>
        /// Start challenge/response protocol.
        /// </summary>
        TDS_MSG_SEC_CHALLENGE = 4,
        /// <summary>
        /// Returned encrypted challenge.
        /// </summary>
        TDS_MSG_SEC_RESPONSE = 5,
        /// <summary>
        /// Start trusted user login protocol.
        /// </summary>
        TDS_MSG_SEC_GETLABEL = 6,
        /// <summary>
        /// Return security labels.
        /// </summary>
        TDS_MSG_SEC_LABEL = 7,
        /// <summary>
        /// CS_MSG_TABLENAME
        /// </summary>
        TDS_MSG_SQL_TBLNAME = 8,
        /// <summary>
        /// Used by interoperability group.
        /// </summary>
        TDS_MSG_GW_RESERVED = 9,
        /// <summary>
        /// Used by OMNI SQL Server.
        /// </summary>
        TDS_MSG_OMNI_CAPABILITIES = 10,
        /// <summary>
        /// Send opaque security token.
        /// </summary>
        TDS_MSG_SEC_OPAQUE = 11,
        /// <summary>
        /// Used during login to obtain the HA Session ID
        /// </summary>
        TDS_MSG_HAFAILOVER = 12,
        /// <summary>
        /// Sometimes a MSG response stream is required by TDS syntax, but the sender has no real information to pass. This message type indicates that the following paramfmt/param streams are meaningless
        /// </summary>
        TDS_MSG_EMPTY = 13,
        /// <summary>
        /// Start alternate encrypted password protocol.
        /// </summary>
        TDS_MSG_SEC_ENCRYPT2 = 14,
        /// <summary>
        /// Return alternate encrypted passwords.
        /// </summary>
        TDS_MSG_SEC_LOGPWD2 = 15,
        //there doesn't seem to be a TDS_MSG_SEC_REMPWD2 to go along with this
        /// <summary>
        /// Returns list of supported ciphers.
        /// </summary>
        TDS_MSG_SEC_SUP_CIPHER = 16,
        /// <summary>
        /// Initiate client connection migration to alternative server via address provided as message parameter.
        /// </summary>
        TDS_MSG_MIG_REQ = 17,
        /// <summary>
        /// Client sends to acknowledge receipt of TDS_MSG_MIG_REQ.
        /// </summary>
        TDS_MSG_MIG_SYNC = 18,
        /// <summary>
        /// Server sends to start actual client migration to alternate server.
        /// </summary>
        TDS_MSG_MIG_CONT = 19,
        /// <summary>
        /// Server sends to abort previous TDS_MSG_MIG_REQ.
        /// </summary>
        TDS_MSG_MIG_IGN = 20,
        /// <summary>
        /// Client sends to original server to indicate that the migration attempt failed. Optional parameter indicates failure reason.
        /// </summary>
        TDS_MSG_MIG_FAIL = 21,
        /// <summary>
        /// Send encrypted user password
        /// </summary>
        TDS_MSG_SEC_LOGPWD3 = 31,
        /// <summary>
        /// Send encrypted remote passwords
        /// </summary>
        TDS_MSG_SEC_REMPWD3 = 32
    }
}
