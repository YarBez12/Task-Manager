; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [324 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [642 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 240
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 274
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 39485524, ; 6: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42639949, ; 7: System.Threading.Thread => 0x28aa24d => 145
	i32 53857724, ; 8: ca/Microsoft.Maui.Controls.resources => 0x335cdbc => 287
	i32 66541672, ; 9: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 68219467, ; 10: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 11: Microsoft.Maui.Graphics.dll => 0x44bb714 => 192
	i32 82292897, ; 12: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 101534019, ; 13: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 258
	i32 113429830, ; 14: zh-HK/Microsoft.Maui.Controls.resources => 0x6c2cd46 => 317
	i32 117431740, ; 15: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 16: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 258
	i32 122350210, ; 17: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 18: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 282
	i32 142721839, ; 19: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 20: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 21: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 22: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 214
	i32 176265551, ; 23: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 24: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 260
	i32 184328833, ; 25: System.ValueTuple.dll => 0xafca281 => 151
	i32 195452805, ; 26: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 316
	i32 199333315, ; 27: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 317
	i32 205061960, ; 28: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 29: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 212
	i32 220171995, ; 30: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 31: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 234
	i32 230752869, ; 32: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 33: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 34: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 35: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 261689757, ; 36: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 217
	i32 276479776, ; 37: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 278686392, ; 38: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 236
	i32 280482487, ; 39: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 233
	i32 280992041, ; 40: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 288
	i32 291076382, ; 41: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 298918909, ; 42: System.Net.Ping.dll => 0x11d123fd => 69
	i32 318968648, ; 43: Xamarin.AndroidX.Activity.dll => 0x13031348 => 203
	i32 321597661, ; 44: System.Numerics => 0x132b30dd => 83
	i32 336156722, ; 45: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 301
	i32 342366114, ; 46: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 235
	i32 347068432, ; 47: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 197
	i32 356389973, ; 48: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 300
	i32 357576608, ; 49: cs/Microsoft.Maui.Controls.resources => 0x15502fa0 => 288
	i32 360082299, ; 50: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 51: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 52: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 53: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 54: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 55: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 56: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 57: _Microsoft.Android.Resource.Designer => 0x17969339 => 320
	i32 403441872, ; 58: WindowsBase => 0x180c08d0 => 165
	i32 435591531, ; 59: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 312
	i32 441335492, ; 60: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 218
	i32 442565967, ; 61: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 62: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 231
	i32 451504562, ; 63: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 64: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 65: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 66: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 67: System.dll => 0x1bff388e => 164
	i32 476646585, ; 68: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 233
	i32 486930444, ; 69: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 246
	i32 498788369, ; 70: System.ObjectModel => 0x1dbae811 => 84
	i32 500358224, ; 71: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 299
	i32 503918385, ; 72: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 293
	i32 504143952, ; 73: Plugin.LocalNotification.dll => 0x1e0ca050 => 193
	i32 513247710, ; 74: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 186
	i32 526420162, ; 75: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527168573, ; 76: hi/Microsoft.Maui.Controls.resources => 0x1f6bf43d => 296
	i32 527452488, ; 77: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 282
	i32 530272170, ; 78: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 539058512, ; 79: Microsoft.Extensions.Logging => 0x20216150 => 182
	i32 540030774, ; 80: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 81: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 82: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 83: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 84: Jsr305Binding => 0x213954e7 => 271
	i32 569601784, ; 85: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 269
	i32 577335427, ; 86: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 592146354, ; 87: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 307
	i32 597488923, ; 88: CommunityToolkit.Maui => 0x239cf51b => 173
	i32 601371474, ; 89: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 90: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 91: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 92: Xamarin.AndroidX.CustomView => 0x2568904f => 223
	i32 639843206, ; 93: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 229
	i32 643868501, ; 94: System.Net => 0x2660a755 => 81
	i32 662205335, ; 95: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 96: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 265
	i32 666292255, ; 97: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 210
	i32 672442732, ; 98: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 99: System.Net.Security => 0x28bdabca => 73
	i32 688181140, ; 100: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 287
	i32 690569205, ; 101: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 102: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 284
	i32 693804605, ; 103: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 104: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 105: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 279
	i32 700358131, ; 106: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 706645707, ; 107: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 302
	i32 709557578, ; 108: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 290
	i32 720511267, ; 109: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 283
	i32 722857257, ; 110: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 735137430, ; 111: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 748832960, ; 112: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 195
	i32 752232764, ; 113: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 114: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 200
	i32 759454413, ; 115: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 116: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 117: System.IO.Compression => 0x2e394f87 => 46
	i32 789151979, ; 118: Microsoft.Extensions.Options => 0x2f0980eb => 185
	i32 790371945, ; 119: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 224
	i32 804715423, ; 120: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 121: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 238
	i32 823281589, ; 122: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 123: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 124: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 125: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 126: Xamarin.AndroidX.Print => 0x3246f6cd => 251
	i32 870878177, ; 127: ar/Microsoft.Maui.Controls.resources => 0x33e88be1 => 286
	i32 873119928, ; 128: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 129: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 130: System.Net.Http.Json => 0x3463c971 => 63
	i32 904024072, ; 131: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 132: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 926902833, ; 133: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 314
	i32 928116545, ; 134: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 274
	i32 952186615, ; 135: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 956575887, ; 136: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 283
	i32 966729478, ; 137: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 272
	i32 967690846, ; 138: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 235
	i32 975236339, ; 139: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 140: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 141: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 142: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 992768348, ; 143: System.Collections.dll => 0x3b2c715c => 12
	i32 993161700, ; 144: zh-Hans/Microsoft.Maui.Controls.resources => 0x3b3271e4 => 318
	i32 994442037, ; 145: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 994547685, ; 146: es/Microsoft.Maui.Controls.resources => 0x3b4797e5 => 292
	i32 1001831731, ; 147: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 148: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 255
	i32 1019214401, ; 149: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 150: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 181
	i32 1029334545, ; 151: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 289
	i32 1031528504, ; 152: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 273
	i32 1035644815, ; 153: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 208
	i32 1036536393, ; 154: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1044663988, ; 155: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1052210849, ; 156: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 242
	i32 1067306892, ; 157: GoogleGson => 0x3f9dcf8c => 177
	i32 1082857460, ; 158: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 159: Xamarin.Kotlin.StdLib => 0x409e66d8 => 280
	i32 1098259244, ; 160: System => 0x41761b2c => 164
	i32 1121599056, ; 161: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 241
	i32 1127624469, ; 162: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 184
	i32 1149092582, ; 163: Xamarin.AndroidX.Window => 0x447dc2e6 => 268
	i32 1170634674, ; 164: System.Web.dll => 0x45c677b2 => 153
	i32 1175144683, ; 165: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 264
	i32 1178241025, ; 166: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 249
	i32 1178797549, ; 167: fi/Microsoft.Maui.Controls.resources => 0x464305ed => 293
	i32 1203215381, ; 168: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 306
	i32 1204270330, ; 169: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 210
	i32 1208641965, ; 170: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1214827643, ; 171: CommunityToolkit.Mvvm => 0x4868cc7b => 175
	i32 1219128291, ; 172: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1234928153, ; 173: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 304
	i32 1243150071, ; 174: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 269
	i32 1253011324, ; 175: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1264511973, ; 176: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 259
	i32 1267360935, ; 177: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 263
	i32 1273260888, ; 178: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 215
	i32 1275534314, ; 179: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 284
	i32 1278448581, ; 180: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 207
	i32 1292207520, ; 181: SQLitePCLRaw.core.dll => 0x4d0585a0 => 196
	i32 1293217323, ; 182: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 226
	i32 1309188875, ; 183: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 184: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 268
	i32 1324164729, ; 185: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 186: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1364015309, ; 187: System.IO => 0x514d38cd => 57
	i32 1376866003, ; 188: Xamarin.AndroidX.SavedState => 0x52114ed3 => 255
	i32 1379779777, ; 189: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 190: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 191: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 219
	i32 1408764838, ; 192: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 193: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 194: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1434145427, ; 195: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 196: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 272
	i32 1439761251, ; 197: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 198: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 199: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 200: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 201: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1461234159, ; 202: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 203: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 204: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 205: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 209
	i32 1470490898, ; 206: Microsoft.Extensions.Primitives => 0x57a5e912 => 186
	i32 1479771757, ; 207: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 208: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 209: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 210: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 256
	i32 1493001747, ; 211: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 296
	i32 1514721132, ; 212: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 291
	i32 1524747670, ; 213: Plugin.LocalNotification => 0x5ae1cd96 => 193
	i32 1536373174, ; 214: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 215: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 216: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 217: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1551623176, ; 218: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 311
	i32 1554762148, ; 219: fr/Microsoft.Maui.Controls.resources => 0x5cabc9a4 => 294
	i32 1565862583, ; 220: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 221: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 222: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 223: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1580413037, ; 224: sv/Microsoft.Maui.Controls.resources => 0x5e33306d => 312
	i32 1582372066, ; 225: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 225
	i32 1591080825, ; 226: zh-Hant/Microsoft.Maui.Controls.resources => 0x5ed5f779 => 319
	i32 1592978981, ; 227: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 228: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 273
	i32 1601112923, ; 229: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 230: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 231: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 232: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 245
	i32 1622358360, ; 233: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 234: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 267
	i32 1634654947, ; 235: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 174
	i32 1635184631, ; 236: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 229
	i32 1636350590, ; 237: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 222
	i32 1639515021, ; 238: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 239: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 240: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 241: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 242: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 261
	i32 1658251792, ; 243: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 270
	i32 1670060433, ; 244: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 217
	i32 1675553242, ; 245: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 246: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 247: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 248: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 249: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 250: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 251: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 281
	i32 1701541528, ; 252: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1711441057, ; 253: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 197
	i32 1720223769, ; 254: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 238
	i32 1726116996, ; 255: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 256: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 257: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 213
	i32 1736233607, ; 258: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 309
	i32 1744735666, ; 259: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 260: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 261: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 262: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 263: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 264: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 265: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 260
	i32 1770582343, ; 266: Microsoft.Extensions.Logging.dll => 0x6988f147 => 182
	i32 1776026572, ; 267: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 268: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 269: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1788241197, ; 270: Xamarin.AndroidX.Fragment => 0x6a96652d => 231
	i32 1808609942, ; 271: Xamarin.AndroidX.Loader => 0x6bcd3296 => 245
	i32 1809966115, ; 272: nb/Microsoft.Maui.Controls.resources => 0x6be1e423 => 304
	i32 1813058853, ; 273: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 280
	i32 1813201214, ; 274: Xamarin.Google.Android.Material => 0x6c13413e => 270
	i32 1818569960, ; 275: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 250
	i32 1818787751, ; 276: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1821794637, ; 277: hu/Microsoft.Maui.Controls.resources => 0x6c96614d => 298
	i32 1824175904, ; 278: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 279: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 280: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 183
	i32 1833534603, ; 281: TasksManager => 0x6d49848b => 0
	i32 1842015223, ; 282: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 315
	i32 1847515442, ; 283: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 200
	i32 1858542181, ; 284: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 285: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1879696579, ; 286: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 287: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 211
	i32 1888955245, ; 288: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 289: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1898237753, ; 290: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 291: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1908813208, ; 292: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 276
	i32 1910275211, ; 293: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 294: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1956758971, ; 295: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1960264639, ; 296: ja/Microsoft.Maui.Controls.resources => 0x74d743bf => 301
	i32 1961813231, ; 297: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 257
	i32 1968388702, ; 298: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 178
	i32 1983156543, ; 299: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 281
	i32 1985761444, ; 300: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 202
	i32 1987243864, ; 301: FluentValidation => 0x7672ef58 => 176
	i32 2011961780, ; 302: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2014344398, ; 303: hr/Microsoft.Maui.Controls.resources => 0x781074ce => 297
	i32 2019465201, ; 304: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 242
	i32 2025202353, ; 305: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 286
	i32 2031763787, ; 306: Xamarin.Android.Glide => 0x791a414b => 199
	i32 2043674646, ; 307: it/Microsoft.Maui.Controls.resources => 0x79d00016 => 300
	i32 2045470958, ; 308: System.Private.Xml => 0x79eb68ee => 88
	i32 2055257422, ; 309: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 237
	i32 2060060697, ; 310: System.Windows.dll => 0x7aca0819 => 154
	i32 2070888862, ; 311: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 312: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 313: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2103459038, ; 314: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 198
	i32 2127167465, ; 315: System.Console => 0x7ec9ffe9 => 20
	i32 2129483829, ; 316: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 275
	i32 2142473426, ; 317: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 318: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 319: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2150663486, ; 320: ko/Microsoft.Maui.Controls.resources => 0x8030853e => 302
	i32 2159891885, ; 321: Microsoft.Maui => 0x80bd55ad => 190
	i32 2165051842, ; 322: ro/Microsoft.Maui.Controls.resources => 0x810c11c2 => 309
	i32 2181898931, ; 323: Microsoft.Extensions.Options.dll => 0x820d22b3 => 185
	i32 2192057212, ; 324: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 183
	i32 2193016926, ; 325: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 326: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 285
	i32 2201231467, ; 327: System.Net.Http => 0x8334206b => 64
	i32 2217644978, ; 328: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 264
	i32 2222056684, ; 329: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2244775296, ; 330: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 246
	i32 2252106437, ; 331: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 332: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2260372635, ; 333: TasksManager.dll => 0x86ba8c9b => 0
	i32 2265110946, ; 334: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 335: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 179
	i32 2267999099, ; 336: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 201
	i32 2270573516, ; 337: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 294
	i32 2279755925, ; 338: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 253
	i32 2289298199, ; 339: th/Microsoft.Maui.Controls.resources => 0x8873eb17 => 313
	i32 2293034957, ; 340: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 341: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 342: System.Net.Mail => 0x88ffe49e => 66
	i32 2305521784, ; 343: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 344: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 205
	i32 2320631194, ; 345: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 346: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 347: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 348: System.Net.Primitives => 0x8c40e0db => 70
	i32 2368005991, ; 349: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2369760409, ; 350: tr/Microsoft.Maui.Controls.resources => 0x8d3fac99 => 314
	i32 2371007202, ; 351: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 178
	i32 2378619854, ; 352: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 353: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2401565422, ; 354: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 355: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 228
	i32 2421380589, ; 356: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2421992093, ; 357: nl/Microsoft.Maui.Controls.resources => 0x905caa9d => 305
	i32 2423080555, ; 358: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 215
	i32 2435356389, ; 359: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 360: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 361: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 362: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 363: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465273461, ; 364: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 195
	i32 2465532216, ; 365: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 218
	i32 2471841756, ; 366: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 367: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 368: Microsoft.Maui.Controls => 0x93dba8a1 => 188
	i32 2483903535, ; 369: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 370: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 371: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 372: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 373: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 240
	i32 2520433370, ; 374: sk/Microsoft.Maui.Controls.resources => 0x963ac2da => 311
	i32 2522472828, ; 375: Xamarin.Android.Glide.dll => 0x9659e17c => 199
	i32 2538310050, ; 376: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2562349572, ; 377: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 378: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2581783588, ; 379: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 241
	i32 2581819634, ; 380: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 263
	i32 2585220780, ; 381: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 382: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 383: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2605712449, ; 384: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 285
	i32 2615233544, ; 385: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 232
	i32 2616218305, ; 386: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 184
	i32 2617129537, ; 387: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 388: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 389: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 222
	i32 2624644809, ; 390: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 227
	i32 2627185994, ; 391: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 392: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 393: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 236
	i32 2663391936, ; 394: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 201
	i32 2663698177, ; 395: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 396: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 397: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 398: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 399: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 400: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 401: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 261
	i32 2715334215, ; 402: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 403: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 404: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 405: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 406: Xamarin.AndroidX.Activity => 0xa2e0939b => 203
	i32 2735172069, ; 407: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 408: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 209
	i32 2740948882, ; 409: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 410: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2758225723, ; 411: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 189
	i32 2764765095, ; 412: Microsoft.Maui.dll => 0xa4caf7a7 => 190
	i32 2765824710, ; 413: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 414: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 279
	i32 2778768386, ; 415: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 266
	i32 2779977773, ; 416: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 254
	i32 2788224221, ; 417: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 232
	i32 2801831435, ; 418: Microsoft.Maui.Graphics => 0xa7008e0b => 192
	i32 2802068195, ; 419: uk/Microsoft.Maui.Controls.resources => 0xa7042ae3 => 315
	i32 2803228030, ; 420: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2806116107, ; 421: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 292
	i32 2810250172, ; 422: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 219
	i32 2819470561, ; 423: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 424: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 425: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 254
	i32 2824502124, ; 426: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2831556043, ; 427: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 305
	i32 2838993487, ; 428: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 243
	i32 2847418871, ; 429: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 275
	i32 2849599387, ; 430: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 431: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 266
	i32 2855708567, ; 432: Xamarin.AndroidX.Transition => 0xaa36a797 => 262
	i32 2857259519, ; 433: el/Microsoft.Maui.Controls.resources => 0xaa4e51ff => 291
	i32 2861098320, ; 434: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 435: Microsoft.Maui.Essentials => 0xaa8a4878 => 191
	i32 2868488919, ; 436: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 174
	i32 2870099610, ; 437: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 204
	i32 2875164099, ; 438: Jsr305Binding.dll => 0xab5f85c3 => 271
	i32 2875220617, ; 439: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2883495834, ; 440: ru/Microsoft.Maui.Controls.resources => 0xabdea79a => 310
	i32 2884993177, ; 441: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 230
	i32 2887636118, ; 442: System.Net.dll => 0xac1dd496 => 81
	i32 2899753641, ; 443: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 444: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 445: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 446: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 447: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2916838712, ; 448: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 267
	i32 2919462931, ; 449: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 450: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 206
	i32 2936416060, ; 451: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 452: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 453: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 454: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 455: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2972252294, ; 456: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 457: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 226
	i32 2987532451, ; 458: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 257
	i32 2996846495, ; 459: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 239
	i32 3016983068, ; 460: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 259
	i32 3023353419, ; 461: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 462: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 234
	i32 3038032645, ; 463: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 320
	i32 3056245963, ; 464: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 256
	i32 3057625584, ; 465: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 247
	i32 3058099980, ; 466: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 278
	i32 3059408633, ; 467: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 468: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 469: System.Threading.Tasks => 0xb755818f => 144
	i32 3077302341, ; 470: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 298
	i32 3090735792, ; 471: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 472: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 473: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 474: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 475: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 476: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 477: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 478: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 479: GoogleGson.dll => 0xbba64c02 => 177
	i32 3159123045, ; 480: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 481: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3178803400, ; 482: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 248
	i32 3192346100, ; 483: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 484: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 485: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 486: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 487: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 225
	i32 3220365878, ; 488: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 489: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3230466174, ; 490: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 276
	i32 3251039220, ; 491: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 492: Xamarin.AndroidX.CardView => 0xc235e84d => 213
	i32 3265493905, ; 493: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 494: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3277815716, ; 495: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 496: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 497: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3286872994, ; 498: SQLite-net.dll => 0xc3e9b3a2 => 194
	i32 3290767353, ; 499: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 500: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 501: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3316684772, ; 502: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 503: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 223
	i32 3317144872, ; 504: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 505: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 211
	i32 3345895724, ; 506: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 252
	i32 3346324047, ; 507: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 249
	i32 3358260929, ; 508: System.Text.Json => 0xc82afec1 => 137
	i32 3360279109, ; 509: SQLitePCLRaw.core => 0xc849ca45 => 196
	i32 3362336904, ; 510: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 204
	i32 3362522851, ; 511: Xamarin.AndroidX.Core => 0xc86c06e3 => 220
	i32 3366347497, ; 512: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 513: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 253
	i32 3395150330, ; 514: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 515: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 516: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 224
	i32 3428513518, ; 517: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 180
	i32 3429136800, ; 518: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 519: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 520: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 227
	i32 3445260447, ; 521: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 522: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 187
	i32 3463511458, ; 523: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 297
	i32 3471940407, ; 524: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 525: Mono.Android => 0xcf3163e6 => 171
	i32 3479583265, ; 526: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 310
	i32 3485117614, ; 527: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 528: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 529: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 216
	i32 3494395880, ; 530: Xamarin.GooglePlayServices.Location.dll => 0xd0483fe8 => 277
	i32 3509114376, ; 531: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 532: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 533: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 534: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3542658132, ; 535: vi/Microsoft.Maui.Controls.resources => 0xd328ac54 => 316
	i32 3560100363, ; 536: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 537: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3596930546, ; 538: de/Microsoft.Maui.Controls.resources => 0xd664cdf2 => 290
	i32 3597029428, ; 539: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 202
	i32 3598340787, ; 540: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 541: System.Linq.dll => 0xd715a361 => 61
	i32 3623444314, ; 542: da/Microsoft.Maui.Controls.resources => 0xd7f95f5a => 289
	i32 3623953038, ; 543: FluentValidation.dll => 0xd801228e => 176
	i32 3624195450, ; 544: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 545: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 251
	i32 3633644679, ; 546: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 206
	i32 3638274909, ; 547: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 548: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 237
	i32 3643854240, ; 549: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 248
	i32 3645089577, ; 550: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3647796983, ; 551: pt-BR/Microsoft.Maui.Controls.resources => 0xd96cf6f7 => 307
	i32 3657292374, ; 552: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 179
	i32 3660523487, ; 553: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3662115805, ; 554: he/Microsoft.Maui.Controls.resources => 0xda4773dd => 295
	i32 3672681054, ; 555: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 556: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 212
	i32 3684561358, ; 557: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 216
	i32 3686075795, ; 558: ms/Microsoft.Maui.Controls.resources => 0xdbb50d93 => 303
	i32 3697841164, ; 559: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 319
	i32 3700866549, ; 560: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 561: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 221
	i32 3716563718, ; 562: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 563: Xamarin.AndroidX.Annotation => 0xdda814c6 => 205
	i32 3724971120, ; 564: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 247
	i32 3732100267, ; 565: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 566: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 567: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 568: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3754567612, ; 569: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 198
	i32 3786282454, ; 570: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 214
	i32 3792276235, ; 571: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 572: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 187
	i32 3802395368, ; 573: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3817368567, ; 574: CommunityToolkit.Maui.dll => 0xe3886bf7 => 173
	i32 3819260425, ; 575: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 576: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 577: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 578: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 181
	i32 3844307129, ; 579: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 580: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 581: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 582: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 583: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3876362041, ; 584: SQLite-net => 0xe70c9739 => 194
	i32 3885497537, ; 585: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 586: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 262
	i32 3888767677, ; 587: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 252
	i32 3889960447, ; 588: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 318
	i32 3896106733, ; 589: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 590: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 220
	i32 3901907137, ; 591: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920810846, ; 592: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 593: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 265
	i32 3928044579, ; 594: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 595: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 596: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 250
	i32 3945713374, ; 597: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 598: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 599: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 208
	i32 3959773229, ; 600: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 239
	i32 3967165417, ; 601: Xamarin.GooglePlayServices.Location => 0xec7623e9 => 277
	i32 3970018735, ; 602: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 278
	i32 3980434154, ; 603: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 313
	i32 3987592930, ; 604: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 295
	i32 4003436829, ; 605: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 606: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 207
	i32 4025784931, ; 607: System.Memory => 0xeff49a63 => 62
	i32 4046471985, ; 608: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 189
	i32 4054681211, ; 609: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 610: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4070331268, ; 611: id/Microsoft.Maui.Controls.resources => 0xf29c5384 => 299
	i32 4073602200, ; 612: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4094352644, ; 613: Microsoft.Maui.Essentials.dll => 0xf40add04 => 191
	i32 4099507663, ; 614: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 615: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 616: Xamarin.AndroidX.Emoji2 => 0xf479582c => 228
	i32 4102112229, ; 617: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 308
	i32 4119206479, ; 618: pl/Microsoft.Maui.Controls.resources => 0xf5861a4f => 306
	i32 4125707920, ; 619: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 303
	i32 4126470640, ; 620: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 180
	i32 4127667938, ; 621: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 622: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 623: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4151237749, ; 624: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 625: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 626: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 627: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 628: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 629: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 244
	i32 4185676441, ; 630: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 631: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 632: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4234116406, ; 633: pt/Microsoft.Maui.Controls.resources => 0xfc5f7d36 => 308
	i32 4256097574, ; 634: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 221
	i32 4258378803, ; 635: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 243
	i32 4260525087, ; 636: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 637: Microsoft.Maui.Controls.dll => 0xfea12dee => 188
	i32 4274623895, ; 638: CommunityToolkit.Mvvm.dll => 0xfec99597 => 175
	i32 4274976490, ; 639: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 640: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 244
	i32 4294763496 ; 641: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 230
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [642 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 240, ; 3
	i32 274, ; 4
	i32 48, ; 5
	i32 80, ; 6
	i32 145, ; 7
	i32 287, ; 8
	i32 30, ; 9
	i32 124, ; 10
	i32 192, ; 11
	i32 102, ; 12
	i32 258, ; 13
	i32 317, ; 14
	i32 107, ; 15
	i32 258, ; 16
	i32 139, ; 17
	i32 282, ; 18
	i32 77, ; 19
	i32 124, ; 20
	i32 13, ; 21
	i32 214, ; 22
	i32 132, ; 23
	i32 260, ; 24
	i32 151, ; 25
	i32 316, ; 26
	i32 317, ; 27
	i32 18, ; 28
	i32 212, ; 29
	i32 26, ; 30
	i32 234, ; 31
	i32 1, ; 32
	i32 59, ; 33
	i32 42, ; 34
	i32 91, ; 35
	i32 217, ; 36
	i32 147, ; 37
	i32 236, ; 38
	i32 233, ; 39
	i32 288, ; 40
	i32 54, ; 41
	i32 69, ; 42
	i32 203, ; 43
	i32 83, ; 44
	i32 301, ; 45
	i32 235, ; 46
	i32 197, ; 47
	i32 300, ; 48
	i32 288, ; 49
	i32 131, ; 50
	i32 55, ; 51
	i32 149, ; 52
	i32 74, ; 53
	i32 145, ; 54
	i32 62, ; 55
	i32 146, ; 56
	i32 320, ; 57
	i32 165, ; 58
	i32 312, ; 59
	i32 218, ; 60
	i32 12, ; 61
	i32 231, ; 62
	i32 125, ; 63
	i32 152, ; 64
	i32 113, ; 65
	i32 166, ; 66
	i32 164, ; 67
	i32 233, ; 68
	i32 246, ; 69
	i32 84, ; 70
	i32 299, ; 71
	i32 293, ; 72
	i32 193, ; 73
	i32 186, ; 74
	i32 150, ; 75
	i32 296, ; 76
	i32 282, ; 77
	i32 60, ; 78
	i32 182, ; 79
	i32 51, ; 80
	i32 103, ; 81
	i32 114, ; 82
	i32 40, ; 83
	i32 271, ; 84
	i32 269, ; 85
	i32 120, ; 86
	i32 307, ; 87
	i32 173, ; 88
	i32 52, ; 89
	i32 44, ; 90
	i32 119, ; 91
	i32 223, ; 92
	i32 229, ; 93
	i32 81, ; 94
	i32 136, ; 95
	i32 265, ; 96
	i32 210, ; 97
	i32 8, ; 98
	i32 73, ; 99
	i32 287, ; 100
	i32 155, ; 101
	i32 284, ; 102
	i32 154, ; 103
	i32 92, ; 104
	i32 279, ; 105
	i32 45, ; 106
	i32 302, ; 107
	i32 290, ; 108
	i32 283, ; 109
	i32 109, ; 110
	i32 129, ; 111
	i32 195, ; 112
	i32 25, ; 113
	i32 200, ; 114
	i32 72, ; 115
	i32 55, ; 116
	i32 46, ; 117
	i32 185, ; 118
	i32 224, ; 119
	i32 22, ; 120
	i32 238, ; 121
	i32 86, ; 122
	i32 43, ; 123
	i32 160, ; 124
	i32 71, ; 125
	i32 251, ; 126
	i32 286, ; 127
	i32 3, ; 128
	i32 42, ; 129
	i32 63, ; 130
	i32 16, ; 131
	i32 53, ; 132
	i32 314, ; 133
	i32 274, ; 134
	i32 105, ; 135
	i32 283, ; 136
	i32 272, ; 137
	i32 235, ; 138
	i32 34, ; 139
	i32 158, ; 140
	i32 85, ; 141
	i32 32, ; 142
	i32 12, ; 143
	i32 318, ; 144
	i32 51, ; 145
	i32 292, ; 146
	i32 56, ; 147
	i32 255, ; 148
	i32 36, ; 149
	i32 181, ; 150
	i32 289, ; 151
	i32 273, ; 152
	i32 208, ; 153
	i32 35, ; 154
	i32 58, ; 155
	i32 242, ; 156
	i32 177, ; 157
	i32 17, ; 158
	i32 280, ; 159
	i32 164, ; 160
	i32 241, ; 161
	i32 184, ; 162
	i32 268, ; 163
	i32 153, ; 164
	i32 264, ; 165
	i32 249, ; 166
	i32 293, ; 167
	i32 306, ; 168
	i32 210, ; 169
	i32 29, ; 170
	i32 175, ; 171
	i32 52, ; 172
	i32 304, ; 173
	i32 269, ; 174
	i32 5, ; 175
	i32 259, ; 176
	i32 263, ; 177
	i32 215, ; 178
	i32 284, ; 179
	i32 207, ; 180
	i32 196, ; 181
	i32 226, ; 182
	i32 85, ; 183
	i32 268, ; 184
	i32 61, ; 185
	i32 112, ; 186
	i32 57, ; 187
	i32 255, ; 188
	i32 99, ; 189
	i32 19, ; 190
	i32 219, ; 191
	i32 111, ; 192
	i32 101, ; 193
	i32 102, ; 194
	i32 104, ; 195
	i32 272, ; 196
	i32 71, ; 197
	i32 38, ; 198
	i32 32, ; 199
	i32 103, ; 200
	i32 73, ; 201
	i32 9, ; 202
	i32 123, ; 203
	i32 46, ; 204
	i32 209, ; 205
	i32 186, ; 206
	i32 9, ; 207
	i32 43, ; 208
	i32 4, ; 209
	i32 256, ; 210
	i32 296, ; 211
	i32 291, ; 212
	i32 193, ; 213
	i32 31, ; 214
	i32 138, ; 215
	i32 92, ; 216
	i32 93, ; 217
	i32 311, ; 218
	i32 294, ; 219
	i32 49, ; 220
	i32 141, ; 221
	i32 112, ; 222
	i32 140, ; 223
	i32 312, ; 224
	i32 225, ; 225
	i32 319, ; 226
	i32 115, ; 227
	i32 273, ; 228
	i32 157, ; 229
	i32 76, ; 230
	i32 79, ; 231
	i32 245, ; 232
	i32 37, ; 233
	i32 267, ; 234
	i32 174, ; 235
	i32 229, ; 236
	i32 222, ; 237
	i32 64, ; 238
	i32 138, ; 239
	i32 15, ; 240
	i32 116, ; 241
	i32 261, ; 242
	i32 270, ; 243
	i32 217, ; 244
	i32 48, ; 245
	i32 70, ; 246
	i32 80, ; 247
	i32 126, ; 248
	i32 94, ; 249
	i32 121, ; 250
	i32 281, ; 251
	i32 26, ; 252
	i32 197, ; 253
	i32 238, ; 254
	i32 97, ; 255
	i32 28, ; 256
	i32 213, ; 257
	i32 309, ; 258
	i32 149, ; 259
	i32 169, ; 260
	i32 4, ; 261
	i32 98, ; 262
	i32 33, ; 263
	i32 93, ; 264
	i32 260, ; 265
	i32 182, ; 266
	i32 21, ; 267
	i32 41, ; 268
	i32 170, ; 269
	i32 231, ; 270
	i32 245, ; 271
	i32 304, ; 272
	i32 280, ; 273
	i32 270, ; 274
	i32 250, ; 275
	i32 2, ; 276
	i32 298, ; 277
	i32 134, ; 278
	i32 111, ; 279
	i32 183, ; 280
	i32 0, ; 281
	i32 315, ; 282
	i32 200, ; 283
	i32 58, ; 284
	i32 95, ; 285
	i32 39, ; 286
	i32 211, ; 287
	i32 25, ; 288
	i32 94, ; 289
	i32 89, ; 290
	i32 99, ; 291
	i32 276, ; 292
	i32 10, ; 293
	i32 87, ; 294
	i32 100, ; 295
	i32 301, ; 296
	i32 257, ; 297
	i32 178, ; 298
	i32 281, ; 299
	i32 202, ; 300
	i32 176, ; 301
	i32 7, ; 302
	i32 297, ; 303
	i32 242, ; 304
	i32 286, ; 305
	i32 199, ; 306
	i32 300, ; 307
	i32 88, ; 308
	i32 237, ; 309
	i32 154, ; 310
	i32 33, ; 311
	i32 116, ; 312
	i32 82, ; 313
	i32 198, ; 314
	i32 20, ; 315
	i32 275, ; 316
	i32 11, ; 317
	i32 162, ; 318
	i32 3, ; 319
	i32 302, ; 320
	i32 190, ; 321
	i32 309, ; 322
	i32 185, ; 323
	i32 183, ; 324
	i32 84, ; 325
	i32 285, ; 326
	i32 64, ; 327
	i32 264, ; 328
	i32 143, ; 329
	i32 246, ; 330
	i32 157, ; 331
	i32 41, ; 332
	i32 0, ; 333
	i32 117, ; 334
	i32 179, ; 335
	i32 201, ; 336
	i32 294, ; 337
	i32 253, ; 338
	i32 313, ; 339
	i32 131, ; 340
	i32 75, ; 341
	i32 66, ; 342
	i32 172, ; 343
	i32 205, ; 344
	i32 143, ; 345
	i32 106, ; 346
	i32 151, ; 347
	i32 70, ; 348
	i32 156, ; 349
	i32 314, ; 350
	i32 178, ; 351
	i32 121, ; 352
	i32 127, ; 353
	i32 152, ; 354
	i32 228, ; 355
	i32 141, ; 356
	i32 305, ; 357
	i32 215, ; 358
	i32 20, ; 359
	i32 14, ; 360
	i32 135, ; 361
	i32 75, ; 362
	i32 59, ; 363
	i32 195, ; 364
	i32 218, ; 365
	i32 167, ; 366
	i32 168, ; 367
	i32 188, ; 368
	i32 15, ; 369
	i32 74, ; 370
	i32 6, ; 371
	i32 23, ; 372
	i32 240, ; 373
	i32 311, ; 374
	i32 199, ; 375
	i32 91, ; 376
	i32 1, ; 377
	i32 136, ; 378
	i32 241, ; 379
	i32 263, ; 380
	i32 134, ; 381
	i32 69, ; 382
	i32 146, ; 383
	i32 285, ; 384
	i32 232, ; 385
	i32 184, ; 386
	i32 88, ; 387
	i32 96, ; 388
	i32 222, ; 389
	i32 227, ; 390
	i32 31, ; 391
	i32 45, ; 392
	i32 236, ; 393
	i32 201, ; 394
	i32 109, ; 395
	i32 158, ; 396
	i32 35, ; 397
	i32 22, ; 398
	i32 114, ; 399
	i32 57, ; 400
	i32 261, ; 401
	i32 144, ; 402
	i32 118, ; 403
	i32 120, ; 404
	i32 110, ; 405
	i32 203, ; 406
	i32 139, ; 407
	i32 209, ; 408
	i32 54, ; 409
	i32 105, ; 410
	i32 189, ; 411
	i32 190, ; 412
	i32 133, ; 413
	i32 279, ; 414
	i32 266, ; 415
	i32 254, ; 416
	i32 232, ; 417
	i32 192, ; 418
	i32 315, ; 419
	i32 159, ; 420
	i32 292, ; 421
	i32 219, ; 422
	i32 163, ; 423
	i32 132, ; 424
	i32 254, ; 425
	i32 161, ; 426
	i32 305, ; 427
	i32 243, ; 428
	i32 275, ; 429
	i32 140, ; 430
	i32 266, ; 431
	i32 262, ; 432
	i32 291, ; 433
	i32 169, ; 434
	i32 191, ; 435
	i32 174, ; 436
	i32 204, ; 437
	i32 271, ; 438
	i32 40, ; 439
	i32 310, ; 440
	i32 230, ; 441
	i32 81, ; 442
	i32 56, ; 443
	i32 37, ; 444
	i32 97, ; 445
	i32 166, ; 446
	i32 172, ; 447
	i32 267, ; 448
	i32 82, ; 449
	i32 206, ; 450
	i32 98, ; 451
	i32 30, ; 452
	i32 159, ; 453
	i32 18, ; 454
	i32 127, ; 455
	i32 119, ; 456
	i32 226, ; 457
	i32 257, ; 458
	i32 239, ; 459
	i32 259, ; 460
	i32 165, ; 461
	i32 234, ; 462
	i32 320, ; 463
	i32 256, ; 464
	i32 247, ; 465
	i32 278, ; 466
	i32 170, ; 467
	i32 16, ; 468
	i32 144, ; 469
	i32 298, ; 470
	i32 125, ; 471
	i32 118, ; 472
	i32 38, ; 473
	i32 115, ; 474
	i32 47, ; 475
	i32 142, ; 476
	i32 117, ; 477
	i32 34, ; 478
	i32 177, ; 479
	i32 95, ; 480
	i32 53, ; 481
	i32 248, ; 482
	i32 129, ; 483
	i32 153, ; 484
	i32 24, ; 485
	i32 161, ; 486
	i32 225, ; 487
	i32 148, ; 488
	i32 104, ; 489
	i32 276, ; 490
	i32 89, ; 491
	i32 213, ; 492
	i32 60, ; 493
	i32 142, ; 494
	i32 100, ; 495
	i32 5, ; 496
	i32 13, ; 497
	i32 194, ; 498
	i32 122, ; 499
	i32 135, ; 500
	i32 28, ; 501
	i32 72, ; 502
	i32 223, ; 503
	i32 24, ; 504
	i32 211, ; 505
	i32 252, ; 506
	i32 249, ; 507
	i32 137, ; 508
	i32 196, ; 509
	i32 204, ; 510
	i32 220, ; 511
	i32 168, ; 512
	i32 253, ; 513
	i32 101, ; 514
	i32 123, ; 515
	i32 224, ; 516
	i32 180, ; 517
	i32 163, ; 518
	i32 167, ; 519
	i32 227, ; 520
	i32 39, ; 521
	i32 187, ; 522
	i32 297, ; 523
	i32 17, ; 524
	i32 171, ; 525
	i32 310, ; 526
	i32 137, ; 527
	i32 150, ; 528
	i32 216, ; 529
	i32 277, ; 530
	i32 155, ; 531
	i32 130, ; 532
	i32 19, ; 533
	i32 65, ; 534
	i32 316, ; 535
	i32 147, ; 536
	i32 47, ; 537
	i32 290, ; 538
	i32 202, ; 539
	i32 79, ; 540
	i32 61, ; 541
	i32 289, ; 542
	i32 176, ; 543
	i32 106, ; 544
	i32 251, ; 545
	i32 206, ; 546
	i32 49, ; 547
	i32 237, ; 548
	i32 248, ; 549
	i32 14, ; 550
	i32 307, ; 551
	i32 179, ; 552
	i32 68, ; 553
	i32 295, ; 554
	i32 171, ; 555
	i32 212, ; 556
	i32 216, ; 557
	i32 303, ; 558
	i32 319, ; 559
	i32 78, ; 560
	i32 221, ; 561
	i32 108, ; 562
	i32 205, ; 563
	i32 247, ; 564
	i32 67, ; 565
	i32 63, ; 566
	i32 27, ; 567
	i32 160, ; 568
	i32 198, ; 569
	i32 214, ; 570
	i32 10, ; 571
	i32 187, ; 572
	i32 11, ; 573
	i32 173, ; 574
	i32 78, ; 575
	i32 126, ; 576
	i32 83, ; 577
	i32 181, ; 578
	i32 66, ; 579
	i32 107, ; 580
	i32 65, ; 581
	i32 128, ; 582
	i32 122, ; 583
	i32 194, ; 584
	i32 77, ; 585
	i32 262, ; 586
	i32 252, ; 587
	i32 318, ; 588
	i32 8, ; 589
	i32 220, ; 590
	i32 2, ; 591
	i32 44, ; 592
	i32 265, ; 593
	i32 156, ; 594
	i32 128, ; 595
	i32 250, ; 596
	i32 23, ; 597
	i32 133, ; 598
	i32 208, ; 599
	i32 239, ; 600
	i32 277, ; 601
	i32 278, ; 602
	i32 313, ; 603
	i32 295, ; 604
	i32 29, ; 605
	i32 207, ; 606
	i32 62, ; 607
	i32 189, ; 608
	i32 90, ; 609
	i32 87, ; 610
	i32 299, ; 611
	i32 148, ; 612
	i32 191, ; 613
	i32 36, ; 614
	i32 86, ; 615
	i32 228, ; 616
	i32 308, ; 617
	i32 306, ; 618
	i32 303, ; 619
	i32 180, ; 620
	i32 50, ; 621
	i32 6, ; 622
	i32 90, ; 623
	i32 21, ; 624
	i32 162, ; 625
	i32 96, ; 626
	i32 50, ; 627
	i32 113, ; 628
	i32 244, ; 629
	i32 130, ; 630
	i32 76, ; 631
	i32 27, ; 632
	i32 308, ; 633
	i32 221, ; 634
	i32 243, ; 635
	i32 7, ; 636
	i32 188, ; 637
	i32 175, ; 638
	i32 110, ; 639
	i32 244, ; 640
	i32 230 ; 641
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ df9aaf29a52042a4fbf800daf2f3a38964b9e958"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
