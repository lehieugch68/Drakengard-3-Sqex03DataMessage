using System;
using System.Collections.Generic;

namespace D3_Sqex03DataMessage
{
    public static class ArchiveConfig
    {
        public static readonly string[] TOCName = new string[] { "PS3TOC.TXT", "PS3TOCPATCH.TXT" };
        public static readonly string[] ArchiveName = new string[] {
            "ALLMESSAGE_SF.XXX","BG00_CHC_10_EVENT.XXX","BG00_CHC_20_EVENT.XXX","BG10_SEA_10_2_EVENT.XXX",
            "BG10_SEA_10_3_EVENT.XXX","BG10_SEA_10_4_EVENT.XXX","BG10_SEA_10_C_EVENT.XXX",
            "BG10_SEA_10_EVENT.XXX","BG10_SEA_20_2_EVENT.XXX","BG10_SEA_20_3_EVENT.XXX",
            "BG10_SEA_20_4_EVENT.XXX","BG10_SEA_20_C_EVENT.XXX","BG10_SEA_20_EVENT.XXX",
            "BG10_SEA_30_1_EVENT.XXX","BG10_SEA_30_EVENT.XXX","BG10_SEA_40_5_EVENT.XXX",
            "BG10_SEA_40_6_EVENT.XXX","BG10_SEA_40_7_EVENT.XXX","BG10_SEA_40_8_EVENT.XXX",
            "BG10_SEA_40_EVENT.XXX","BG13_SEA_10_C_EVENT.XXX","BG13_SEA_10_EVENT.XXX",
            "BG14_SEA_10_C_EVENT.XXX","BG14_SEA_10_C_EVENT0.XXX","BG14_SEA_10_EVENT.XXX",
            "BG20_60_LD02_EVENT.XXX","BG20_60_LD04_EVENT.XXX","BG20_60_LD08_EVENT.XXX",
            "BG20_MNT_10_C_EVENT.XXX","BG20_MNT_10_EVENT.XXX","BG20_MNT_20_2_EVENT.XXX",
            "BG20_MNT_20_3_EVENT.XXX","BG20_MNT_20_4_EVENT.XXX","BG20_MNT_20_C_EVENT.XXX",
            "BG20_MNT_20_EVENT.XXX","BG20_MNT_40_1_EVENT.XXX","BG20_MNT_40_C_EVENT.XXX",
            "BG20_MNT_40_EVENT.XXX","BG20_MNT_50_2_EVENT.XXX","BG20_MNT_50_3_EVENT.XXX",
            "BG20_MNT_50_4_EVENT.XXX","BG20_MNT_50_EVENT.XXX","BG23_MNT_10_C_EVENT.XXX",
            "BG23_MNT_10_EVENT.XXX","BG23_MNT_20_EVENT.XXX","BG24_MNT_10_C_EVENT.XXX",
            "BG24_MNT_10_EVENT.XXX","BG30_FOR_00_C_EVENT.XXX","BG30_FOR_10_2_EVENT.XXX",
            "BG30_FOR_10_3_EVENT.XXX","BG30_FOR_10_4_EVENT.XXX","BG30_FOR_10_C_EVENT.XXX",
            "BG30_FOR_10_EVENT.XXX","BG30_FOR_20_EVENT.XXX","BG30_FOR_30_1_EVENT.XXX",
            "BG30_FOR_30_EVENT.XXX","BG30_FOR_40_C_EVENT.XXX","BG30_FOR_40_EVENT.XXX",
            "BG30_FOR_50_2_EVENT.XXX","BG30_FOR_50_3_EVENT.XXX","BG30_FOR_50_4_EVENT.XXX",
            "BG30_FOR_50_EVENT.XXX","BG30_FOR_60_EVENT.XXX","BG32_FOR_10_C_EVENT.XXX",
            "BG32_FOR_10_EVENT.XXX","BG32_FOR_20_C_EVENT.XXX","BG32_FOR_20_EVENT.XXX",
            "BG32_FOR_30_EVENT.XXX","BG32_FOR_40_C_EVENT.XXX","BG32_FOR_40_EVENT.XXX",
            "BG32_FOR_50_EVENT.XXX","BG33_FOR_10_C_EVENT.XXX","BG33_FOR_10_EVENT.XXX",
            "BG33_FOR_20_EVENT.XXX","BG40_SND_10_2_EVENT.XXX","BG40_SND_10_3_EVENT.XXX",
            "BG40_SND_10_4_EVENT.XXX","BG40_SND_10_C_EVENT.XXX","BG40_SND_10_EVENT.XXX",
            "BG40_SND_20_2_EVENT.XXX","BG40_SND_20_3_EVENT.XXX","BG40_SND_20_4_EVENT.XXX",
            "BG40_SND_20_C_EVENT.XXX","BG40_SND_20_EVENT.XXX","BG40_SND_30_1_EVENT.XXX",
            "BG40_SND_30_EVENT.XXX","BG40_SND_40_EVENT.XXX","BG41_SND_10_EVENT.XXX",
            "BG41_SND_20_C_EVENT.XXX","BG41_SND_20_EVENT.XXX","BG41_SND_30_EVENT.XXX",
            "BG43_20_LD00_EVENT.XXX","BG43_20_LD01_EVENT.XXX","BG43_SND_10_C_EVENT.XXX",
            "BG43_SND_10_EVENT.XXX","BG45_SND_10_C_EVENT.XXX","BG45_SND_10_EVENT.XXX",
            "BG50_CHC_00_C_EVENT.XXX","BG50_CHC_10_C_EVENT.XXX","BG50_CHC_20_2_EVENT.XXX",
            "BG50_CHC_20_3_EVENT.XXX","BG50_CHC_20_4_EVENT.XXX","BG50_CHC_20_EVENT.XXX",
            "BG50_CHC_30_2_EVENT.XXX","BG50_CHC_30_3_EVENT.XXX","BG50_CHC_30_4_EVENT.XXX",
            "BG50_CHC_30_EVENT.XXX","BG50_CHC_40_1_EVENT.XXX","BG50_CHC_40_EVENT.XXX",
            "BG50_M5010_LD00_EVENT.XXX","BG50_M5010_LD01_EVENT.XXX","BG51_CHC_10_EVENT.XXX",
            "BG51_CHC_20_EVENT.XXX","BG53_CHC_10_EVENT.XXX","MISSIONMESSAGE_SF.XXX",
            "STAFFROLLMSG_SF.XXX",


            "MISSIONMESSAGE_D_00_SF.XXX", "MISSIONMESSAGE_D_10_SF.XXX", "MISSIONMESSAGE_D_20_SF.XXX",
            "MISSIONMESSAGE_D_30_SF.XXX", "MISSIONMESSAGE_D_50_SF.XXX", "MISSIONMESSAGE_D_40_SF.XXX",

            "ADDSCENARIO00001_INFO_SF.XXX", "ADDSCENARIO00002_INFO_SF.XXX", "ADDSCENARIO00003_INFO_SF.XXX",
            "ADDSCENARIO00004_INFO_SF.XXX", "ADDSCENARIO00005_INFO_SF.XXX", "ADDSCENARIO00000_INFO_SF.XXX",

            "ADDWEAPONCLOTHE0_INFO_SF.XXX", "ADDWEAPONCLOTHE1_INFO_SF.XXX", "ADDWEAPONCLOTHE2_INFO_SF.XXX",
            "ADDWEAPONCLOTHE3_INFO_SF.XXX", "ADDWEAPONCLOTHE4_INFO_SF.XXX", "ADDWEAPONCLOTHE5_INFO_SF.XXX",
            "ADDWEAPONCLOTHE6_INFO_SF.XXX", "ADDWEAPONCLOTHE7_INFO_SF.XXX", "ADDWEAPONCLOTHE8_INFO_SF.XXX",
            "ADDWEAPONCLOTHE9_INFO_SF.XXX"
        };
        public static readonly uint Signature = 0x9E2A83C1;
        public static readonly uint UncompressedFlags = 0x80880009;
        public static readonly byte[] UncompressedFlagsBytes = new byte[] { 0x80, 0x88, 0x00, 0x09 };
        public static readonly long CompressionTypeOffset = 109;
        public static readonly long PackageFlagsOffset = 21;
        public static readonly long TableOffset = 25;
        public static readonly Dictionary<string, string> GameCodeDict = new Dictionary<string, string>()
        {
            { '\u0001'.ToString(), "{01}" },
            { '\u0002'.ToString(), "{02}" },
            { '\u0003'.ToString(), "{03}" },
            { '\u0004'.ToString(), "{04}" },
            { '\u0005'.ToString(), "{LF}" },
            { '\u0006'.ToString(), "{06}" },
            { '\u0008'.ToString(), "{08}" },
            { '\u0009'.ToString(), "{09}" },
            { '\u0010'.ToString(), "{10}" },
            { '\u000a'.ToString(), "{0A}" },
            { '\u000b'.ToString(), "{0B}" },
            { '\u000c'.ToString(), "{0C}" },
            { '\u000d'.ToString(), "{0D}" },
            { '\u000f'.ToString(), "{0F}" },
            { '\u25b2'.ToString(), "{25B2}" },
            { '\u25BC'.ToString(), "{25BC}" },
        };
    }
}
