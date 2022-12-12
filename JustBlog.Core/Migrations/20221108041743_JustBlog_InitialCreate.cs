using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustBlog.Core.Migrations
{
    public partial class JustBlog_InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1026)", maxLength: 1026, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ShortDescription = table.Column<string>(name: "Short Description", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PostContent = table.Column<string>(name: "Post Content", type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ViewCount = table.Column<int>(name: "View Count", type: "int", nullable: false, defaultValue: 0),
                    RateCount = table.Column<int>(name: "Rate Count", type: "int", nullable: false, defaultValue: 0),
                    TotalRate = table.Column<int>(name: "Total Rate", type: "int", nullable: false, defaultValue: 0),
                    PostedOn = table.Column<DateTime>(name: "Posted On", type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(1026)", maxLength: 1026, nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "Commodo massa sociosqu placerat eleifend iaculis vitae lectus lorem scelerisque praesent finibus", "Phasellus himenaeos", "vel-porttitor" },
                    { 2, "Mattis ultricies elit a hendrerit fermentum nunc quis lobortis dignissim tristique id", "Odio tempor", "rhoncus-purus" },
                    { 3, "Et non quisque torquent cras luctus integer mi feugiat cursus volutpat eros", "Inceptos est", "nunc-tellus" },
                    { 4, "Tristique mauris urna pellentesque nibh semper curabitur etiam et velit vehicula ac", "Sodales risus", "sit-integer" },
                    { 5, "Tellus class nisi ac placerat placerat dolor eu ante maximus tempor at", "Vel augue", "rutrum-donec" },
                    { 6, "Porta ex platea consequat et per quam lacinia semper mattis metus lacinia", "Augue fames", "nunc-inceptos" },
                    { 7, "Pellentesque id condimentum pulvinar mattis lacinia in quis hendrerit vestibulum leo praesent", "Finibus eget", "himenaeos-euismod" },
                    { 8, "Arcu semper laoreet nostra dignissim sagittis quam porta sapien massa metus tellus", "Quam diam", "ad-ac" },
                    { 9, "Convallis felis lectus erat elit pulvinar ultrices vestibulum nibh nisl efficitur litora", "Ultricies massa", "blandit-aenean" },
                    { 10, "Leo et vitae mollis facilisis habitasse conubia donec eleifend eros arcu volutpat", "Urna taciti", "odio-egestas" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24add274-998b-4784-911a-4e1fece82c63", "32b452fc-51d5-4a83-b411-e1906345a068", "Blog Owner", "BLOG OWNER" },
                    { "56302830-a686-4fbe-a8ba-9b297ffbcc35", "e4bd5d34-1481-4d79-9a0a-e4412fe3e410", "Admin", "ADMIN" },
                    { "7dd5ab7d-0181-4761-8d5b-60628b911ee5", "59019f1c-2e73-47ce-8990-788eaf2e672b", "Contributor", "CONTRIBUTOR" },
                    { "96e4e54a-b52f-4ad0-a398-028954aa7c3a", "a1cc510d-6e48-472b-b0c4-908026afc5cd", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 29, "Nam tellus mattis vitae luctus aliquam fames mi feugiat in eleifend pretium facilisis", "Varius molestie sociosqu", "ut-fringilla-tortor" },
                    { 2, 18, "Laoreet adipiscing nunc quam porta lectus sem phasellus elementum himenaeos primis mauris fermentum", "Cursus mattis arcu", "ultricies-hendrerit-turpis" },
                    { 3, 19, "Fusce sodales consequat nulla placerat efficitur ante commodo orci velit himenaeos fringilla sem", "Aenean fermentum auctor", "tortor-nisi-venenatis" },
                    { 4, 16, "Molestie placerat porta aenean quam facilisis iaculis in ad auctor nam fringilla neque", "Orci porttitor tristique", "congue-eros-curabitur" },
                    { 5, 17, "A aenean proin mattis turpis lobortis fermentum curabitur etiam hendrerit orci erat leo", "Urna neque feugiat", "et-vehicula-neque" },
                    { 6, 16, "Nibh a cursus congue eros dui ante lacinia commodo massa sodales nunc eu", "Class lorem turpis", "tellus-amet-platea" },
                    { 7, 26, "Metus nulla lacinia himenaeos est sem sem habitasse eros eleifend magna auctor scelerisque", "Litora accumsan elit", "fusce-taciti-luctus" },
                    { 8, 18, "Dictumst cursus varius duis quisque porttitor dapibus metus rutrum lobortis augue nullam enim", "Primis quis porttitor", "massa-phasellus-eleifend" },
                    { 9, 21, "Vulputate augue conubia nullam id interdum congue molestie lobortis massa taciti lacinia dui", "Varius sagittis eu", "auctor-nibh-venenatis" },
                    { 10, 25, "Vivamus augue mi sagittis maximus interdum pulvinar tortor pretium nisi donec cras nostra", "Felis fringilla faucibus", "venenatis-commodo-non" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06f42c04-8ca6-4a49-9123-612fe03d2eb1", "Ultrices eros dolor magna porttitor commodo nullam tristique tellus sollicitudin", 0, 39, "7ede872d-e39a-4273-87d3-27d859332358", "kienct5@gmail.com", true, false, null, "KIENCT5@GMAIL.COM", "KIENCT5", "AQAAAAEAACcQAAAAEDMBVS3CxuVrtXKv14E1OdlSYO06y0AeLSPQ5aFALTnk/kqFP1t9u+Yo5pwpTazg8A==", null, false, "6f353210-216e-4eb7-9dd5-2974404311ba", false, "kienct5" },
                    { "0fd0513a-b066-4b9a-b7f7-3278406fbfa1", "Eleifend volutpat nec lorem arcu enim tellus et ut cursus", 0, 20, "b612943e-ce40-418f-b97e-6af7809a20c6", "kienct6@gmail.com", true, false, null, "KIENCT6@GMAIL.COM", "KIENCT6", "AQAAAAEAACcQAAAAEL3b7oIqv9MLYM2aepCBFnV14+kDVl30Rz3XxY9LYR+dAVqau8obmxPUYOSI56l5rg==", null, false, "242ef0d0-0e88-493e-a7d4-c8bb03ad2ee6", false, "kienct6" },
                    { "9c084822-4317-4634-aedd-df327edd8e02", "In purus class laoreet volutpat felis erat ante elit consectetur", 0, 43, "851c7359-cf12-4d72-84ab-3c80ff6be64d", "kienct7@gmail.com", true, false, null, "KIENCT6@GMAIL.COM", "KIENCT7", "AQAAAAEAACcQAAAAEAeDGw0vdHY2VQd2O7yU/4lDRCHxVhpLxRA2Y054cE8bLO0hVjDVx0UP4OFCwZLg8g==", null, false, "50331815-6759-4110-ad5e-cefa412de249", false, "kienct7" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "Post Content", "Posted On", "Published", "Rate Count", "Short Description", "Title", "Total Rate", "UrlSlug", "View Count" },
                values: new object[,]
                {
                    { 1, 2, null, "Sagittis, nunc, ex, nulla tortor maecenas massa, erat, massa purus nostra, tellus, nunc in class quis. Dictum varius lorem, magna, nunc finibus a, quis, tincidunt dapibus vitae pulvinar. Phasellus placerat eu, auctor, per ad egestas litora sollicitudin magna, justo nulla sem dictumst. Laoreet, gravida nisi, aliquet sit eros leo, vel, ante, euismod, id elit. Magna, lorem, dui, quam, rhoncus sed, dolor varius enim, magna eros, sed tortor. Blandit, sociosqu suscipit conubia eget etiam inceptos adipiscing sagittis, ante nullam orci velit nisi, eros eu, magna nibh, primis.", new DateTime(2022, 11, 6, 19, 10, 42, 673, DateTimeKind.Local).AddTicks(5224), true, 10, "Molestie tempor eros convallis nibh elit facilisis sed sagittis eu massa varius morbi", "Quam mauris amet", 191, "pellentesque-posuere-ex", 140 },
                    { 2, 2, null, "Vulputate sed varius, quam quis, nunc euismod, volutpat, molestie orci, dapibus lobortis luctus. Vestibulum, dictumst enim, cras porttitor, magna convallis consequat sollicitudin suscipit enim mattis, platea ultrices nec, lectus blandit fringilla. Tortor, leo non mollis lorem tristique viverra est varius, risus vel, nisi, odio, ante, id, ultricies finibus, enim. Tempor lobortis placerat ipsum eu sed rutrum nostra, non cras quam, massa, platea ligula. Leo amet augue in consectetur vehicula nulla convallis rutrum pellentesque ultrices ex.", new DateTime(2022, 10, 30, 15, 13, 42, 673, DateTimeKind.Local).AddTicks(7402), true, 15, "Non metus massa ultrices cursus lectus aliquam eleifend malesuada arcu rutrum venenatis orci", "Mauris amet mi", 248, "suscipit-sem-laoreet", 180 },
                    { 3, 5, null, "Purus ligula mi placerat, auctor, sem turpis leo, maximus placerat vivamus blandit pellentesque massa arcu. Duis eget magna, primis hac tincidunt nulla malesuada maximus pulvinar neque, molestie gravida dictumst consequat euismod dignissim. Feugiat sodales arcu, dictum massa, aliquet enim, nisi, felis malesuada augue praesent odio tortor, aliquam pellentesque amet. Auctor fermentum dapibus eleifend, id, nisi blandit, nam porttitor ornare sem facilisis egestas luctus. Ac, finibus, conubia fusce nibh, lacus efficitur tempus interdum class tortor duis. Odio, commodo congue, imperdiet posuere suspendisse porttitor sed ornare amet. Eget vitae, suspendisse rhoncus eu, sem ultrices elit luctus, id enim euismod nullam mauris.", new DateTime(2022, 11, 3, 18, 0, 42, 673, DateTimeKind.Local).AddTicks(9893), true, 19, "Eros cursus euismod donec venenatis euismod tempus auctor semper sem egestas porta consequat", "Tempus blandit lobortis", 233, "sagittis-arcu-dui", 183 },
                    { 4, 3, null, "Tellus dapibus interdum, mattis adipiscing mi, luctus, convallis blandit nec mi quam. Vitae accumsan lacinia arcu scelerisque amet, risus auctor, cursus erat volutpat tortor, lacus platea magna, nec eleifend class quam. Tellus himenaeos mollis consequat taciti tristique vivamus interdum fringilla, ut hendrerit nibh adipiscing ante. Varius tempus orci, pretium consectetur elit posuere suscipit massa, libero ligula, arcu interdum, sociosqu.", new DateTime(2022, 11, 7, 8, 23, 42, 674, DateTimeKind.Local).AddTicks(1755), true, 22, "Sodales duis dui orci elementum erat sem tellus est mollis in mauris odio", "Torquent faucibus ornare", 135, "blandit-arcu-conubia", 225 },
                    { 5, 4, null, "Ac nisi, lacinia nibh, ullamcorper pharetra facilisis ante, lectus, varius. Non, nam tempor maecenas vehicula lectus, molestie vestibulum, suscipit imperdiet. Orci proin euismod, velit quis, neque cras conubia justo lobortis congue, mauris inceptos libero lectus facilisis. Sagittis, ligula vel, blandit eleifend, posuere, non, porttitor, est pharetra nibh id. Odio, mattis litora sagittis curabitur dolor commodo, mattis, lacinia, odio urna ante, rhoncus, neque. Curabitur dapibus cursus libero efficitur in quis lorem tincidunt nisl amet mauris. Sem, eros, molestie turpis dapibus tincidunt lacus arcu torquent phasellus elit justo gravida egestas.", new DateTime(2022, 11, 3, 10, 36, 42, 674, DateTimeKind.Local).AddTicks(4294), true, 23, "Rhoncus dolor blandit orci congue dapibus sollicitudin sem quis mollis odio facilisis urna", "Sollicitudin mauris mi", 140, "tellus-ligula-neque", 149 },
                    { 6, 2, null, "Sed platea aptent dui molestie ligula, lacinia, mauris ultricies vestibulum, proin luctus venenatis in commodo vel. Mauris ornare lacinia non pulvinar mauris, ligula efficitur dolor purus odio. Ipsum volutpat, ornare class maximus euismod, magna, consequat erat, torquent libero dui commodo taciti integer mattis, auctor. Convallis taciti vitae bibendum, sem metus felis tempus tortor, nullam augue gravida imperdiet porttitor, fusce aenean.", new DateTime(2022, 11, 3, 17, 36, 42, 674, DateTimeKind.Local).AddTicks(6025), true, 15, "Habitasse euismod porttitor nisi quisque diam varius dapibus phasellus nisi porttitor iaculis pharetra", "Interdum nibh commodo", 249, "tellus-tempor-luctus", 114 },
                    { 7, 5, null, "Ut ullamcorper dapibus class laoreet libero sem, curabitur rutrum neque, gravida. Aliquam placerat vel enim, a duis class pulvinar, neque, pulvinar nisi varius nec, tortor finibus, ornare. Rutrum mattis, porttitor viverra commodo, nam ultricies magna, ullamcorper luctus, hac risus quam vivamus auctor nibh arcu, pellentesque. Elit, ultricies vel pulvinar at litora curabitur consectetur sodales accumsan ullamcorper pulvinar. Diam erat finibus nibh massa donec quis, commodo leo nostra, litora quam, porta, euismod.", new DateTime(2022, 10, 31, 3, 21, 42, 674, DateTimeKind.Local).AddTicks(8106), true, 19, "Porttitor euismod dolor id sit non sagittis sagittis vehicula quam massa ad semper", "Litora sodales eleifend", 225, "felis-sagittis-class", 138 },
                    { 8, 5, null, "Bibendum finibus, suspendisse pretium fringilla, cursus nisi diam adipiscing fusce varius eleifend, sit. Commodo et himenaeos dapibus mi, porta tellus, velit tristique adipiscing sollicitudin orci quis ante, posuere, sit. Erat, fringilla, est cursus sed lacinia, feugiat amet, quam ante, interdum. Aliquet ac sagittis, arcu quis, congue, volutpat, placerat et sem, augue nisl. Magna, ante sapien convallis amet elit velit ante, posuere praesent. Libero ultrices elit, velit vivamus commodo, bibendum erat at, elit dolor, suscipit urna, ex cras vitae sem, integer. Malesuada himenaeos tortor neque in ipsum id, lorem fusce viverra.", new DateTime(2022, 11, 1, 17, 0, 42, 675, DateTimeKind.Local).AddTicks(648), true, 25, "Auctor elementum cras nisi blandit primis aliquet arcu ante purus justo rhoncus iaculis", "Tempor mattis quis", 152, "iaculis-mauris-accumsan", 280 },
                    { 9, 3, null, "Ultricies urna, pellentesque ornare eu ullamcorper mattis facilisis pharetra luctus arcu, conubia dictum metus a viverra gravida nulla. Eleifend, nam posuere eleifend placerat, nibh, eu vestibulum mauris, felis lorem cursus, nec eget accumsan. Litora leo hac pulvinar luctus, congue auctor, velit amet, quis, nisi, rutrum dui, dictum nulla, himenaeos. Urna convallis rhoncus donec ut consequat vitae porta, tortor feugiat, massa, commodo luctus blandit quisque himenaeos ante commodo. Enim sociosqu commodo, interdum, posuere pellentesque nisi, erat, nec, efficitur tempus est ex, rhoncus eleifend, malesuada accumsan adipiscing. Mauris quis, porttitor volutpat ligula ante, adipiscing egestas maecenas phasellus sagittis, leo, curabitur congue, non, justo. Finibus quis, maximus lacinia, laoreet erat, nostra, urna amet, turpis tempor justo.", new DateTime(2022, 10, 31, 1, 0, 42, 675, DateTimeKind.Local).AddTicks(3237), true, 17, "Metus neque vivamus enim lorem proin viverra aenean pulvinar eu volutpat sagittis libero", "Orci et semper", 160, "ex-dictumst-proin", 138 },
                    { 10, 3, null, "Vulputate aliquet ac, pretium nisi molestie mi arcu cursus, sem proin inceptos. Amet, blandit, ante, sed nibh, laoreet, luctus tempus aenean nunc, nam. Eleifend, risus posuere, sem, id, commodo et, platea ligula eleifend. Pellentesque sed, tempor iaculis conubia ultrices, tellus adipiscing neque, mattis taciti non.", new DateTime(2022, 11, 6, 11, 31, 42, 675, DateTimeKind.Local).AddTicks(5061), true, 12, "Cras faucibus sapien ex commodo pretium ornare lacinia ultrices ante curabitur rutrum quam", "Id turpis dapibus", 273, "enim-dapibus-odio", 242 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "24add274-998b-4784-911a-4e1fece82c63", "06f42c04-8ca6-4a49-9123-612fe03d2eb1" },
                    { "7dd5ab7d-0181-4761-8d5b-60628b911ee5", "0fd0513a-b066-4b9a-b7f7-3278406fbfa1" },
                    { "96e4e54a-b52f-4ad0-a398-028954aa7c3a", "9c084822-4317-4634-aedd-df327edd8e02" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Sagittis diam quisque", "Et, quam vivamus maecenas nibh sagittis aenean laoreet, quam, habitasse. Faucibus vitae, lacinia amet, massa vehicula sit magna laoreet taciti non fames a.", new DateTime(2022, 11, 1, 7, 28, 42, 676, DateTimeKind.Local).AddTicks(3392), "quis@enim.com", "Magna nullam", 9 },
                    { 2, "Vehicula est auctor", "Habitasse donec hendrerit inceptos nam a eleifend, dignissim vel volutpat lacinia, euismod finibus arcu justo eros vestibulum.", new DateTime(2022, 10, 31, 10, 3, 42, 676, DateTimeKind.Local).AddTicks(4572), "eros@faucibus.com", "Tristique urna", 5 },
                    { 3, "Orci nunc ultricies", "Erat, sem, felis habitasse est tempor nisi, quis sed sit sodales ante, platea venenatis leo.", new DateTime(2022, 10, 31, 11, 0, 42, 676, DateTimeKind.Local).AddTicks(5864), "pulvinar@lacinia.com", "Lobortis ullamcorper", 2 },
                    { 4, "Sodales pretium sem", "Vehicula habitasse eu, vivamus a placerat semper class suspendisse diam.", new DateTime(2022, 11, 5, 20, 38, 42, 676, DateTimeKind.Local).AddTicks(7066), "sed@odio.com", "Aliquam hendrerit", 9 },
                    { 5, "Aliquam erat vel", "Dui, primis varius, a, lectus non, libero iaculis a facilisis purus malesuada tempor, interdum elementum platea. Ultrices, bibendum luctus, dui imperdiet orci auctor augue maecenas erat.", new DateTime(2022, 11, 5, 1, 14, 42, 676, DateTimeKind.Local).AddTicks(8541), "diam@lectus.com", "Orci etiam", 6 },
                    { 6, "Adipiscing dignissim arcu", "Dui feugiat felis proin volutpat hendrerit auctor mi, porta purus maecenas.", new DateTime(2022, 11, 6, 17, 5, 42, 676, DateTimeKind.Local).AddTicks(9745), "adipiscing@semper.com", "Orci lectus", 9 },
                    { 7, "Fringilla porttitor convallis", "Dapibus eu nam ultricies quis, finibus, mauris, urna, aenean proin convallis lorem volutpat vivamus vulputate sagittis, non eu, dictum.", new DateTime(2022, 11, 1, 18, 16, 42, 677, DateTimeKind.Local).AddTicks(949), "quam@faucibus.com", "Pharetra auctor", 3 },
                    { 8, "Magna condimentum lorem", "Vivamus nam magna est sagittis, tempor, diam pulvinar nec amet orci.", new DateTime(2022, 11, 8, 8, 6, 42, 677, DateTimeKind.Local).AddTicks(2122), "sollicitudin@morbi.com", "Sagittis vestibulum", 7 },
                    { 9, "Tempor consectetur pellentesque", "Morbi dignissim odio ut quisque fermentum ullamcorper ipsum facilisis nulla.", new DateTime(2022, 10, 30, 0, 43, 42, 677, DateTimeKind.Local).AddTicks(3346), "ligula@commodo.com", "Auctor magna", 3 },
                    { 10, "Malesuada sit metus", "Primis tortor ultrices, adipiscing suspendisse nibh, blandit tellus a et, lobortis ut feugiat, dui porta, laoreet.", new DateTime(2022, 11, 7, 21, 53, 42, 677, DateTimeKind.Local).AddTicks(4518), "libero@nisi.com", "Facilisis urna", 9 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_TagId",
                table: "PostTagMaps",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
