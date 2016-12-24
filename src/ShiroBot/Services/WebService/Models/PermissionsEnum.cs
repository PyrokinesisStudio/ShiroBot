﻿
namespace ShiroBot.Services.WebService.Models
{
    public enum PermissionsEnum
    {
        KickMembers        = 0x00000002,
        BanMembers         = 0x00000004,
        Administrator      = 0x00000008,
        ManageChannels     = 0x00000010,
        ManageGuild        = 0x00000020,
        AddReactions       = 0x00000040,
        ReadMessages       = 0x00000400,
        SendMessages       = 0x00000800,
        SendTtsMessages    = 0x00001000,
        ManageMessages     = 0x00002000,
        EmbedLinks         = 0x00004000,
        AttachFiles        = 0x00008000,
        ReadMessageHistory = 0x00010000,
        MentionEveryone    = 0x00020000,
        UseExternalEmojis  = 0x00040000,
        Connect            = 0x00100000,
        Speak              = 0x00200000,
        MuteMembers        = 0x00400000,
        DeafenMembers      = 0x00800000,
        MoveMembers        = 0x01000000,
        UseVad             = 0x02000000,
        ChangeNickname     = 0x04000000,
        ManageNickname     = 0x08000000,
        ManageRoles        = 0x10000000,
        ManageWebhooks     = 0x20000000,
        ManageEmojis       = 0x40000000,

        // Permission Groups
        AllPermissions =
            Administrator ^
            AllPermissionsNoAdmin,

        AllPermissionsNoAdmin =
            KickMembers ^
            BanMembers ^
            ManageChannels ^
            ManageGuild ^
            AddReactions ^
            ReadMessages ^
            SendMessages ^
            SendTtsMessages ^
            ManageMessages ^
            EmbedLinks ^
            AttachFiles ^
            ReadMessageHistory ^
            MentionEveryone ^
            UseExternalEmojis ^
            Connect ^
            Speak ^
            MuteMembers ^
            DeafenMembers ^
            MoveMembers ^
            UseVad ^
            ChangeNickname ^
            ManageNickname ^
            ManageRoles ^
            ManageWebhooks ^
            ManageEmojis,
    }
}