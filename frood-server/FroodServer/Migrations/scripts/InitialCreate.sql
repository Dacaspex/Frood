CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
                                                       "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
                                                       "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Spaces" (
                          "Id" TEXT NOT NULL CONSTRAINT "PK_Spaces" PRIMARY KEY,
                          "Name" TEXT NOT NULL
);

CREATE TABLE "Partners" (
                            "Id" TEXT NOT NULL CONSTRAINT "PK_Partners" PRIMARY KEY,
                            "Name" TEXT NOT NULL,
                            "Secret" TEXT NOT NULL,
                            "SpaceId" TEXT NOT NULL,
                            CONSTRAINT "FK_Partners_Spaces_SpaceId" FOREIGN KEY ("SpaceId") REFERENCES "Spaces" ("Id") ON DELETE CASCADE
);

CREATE TABLE "MoodReports" (
                               "Id" TEXT NOT NULL CONSTRAINT "PK_MoodReports" PRIMARY KEY,
                               "UpdatedAt" TEXT NOT NULL,
                               "GlobalMood" REAL NOT NULL,
                               "PartnerId" TEXT NOT NULL,
                               CONSTRAINT "FK_MoodReports_Partners_PartnerId" FOREIGN KEY ("PartnerId") REFERENCES "Partners" ("Id") ON DELETE CASCADE
);

CREATE TABLE "MoodCategories" (
                                  "Id" TEXT NOT NULL CONSTRAINT "PK_MoodCategories" PRIMARY KEY,
                                  "Name" TEXT NOT NULL,
                                  "MoodReportId" TEXT NOT NULL,
                                  CONSTRAINT "FK_MoodCategories_MoodReports_MoodReportId" FOREIGN KEY ("MoodReportId") REFERENCES "MoodReports" ("Id") ON DELETE CASCADE
);

CREATE TABLE "MoodTopics" (
                              "Id" TEXT NOT NULL CONSTRAINT "PK_MoodTopics" PRIMARY KEY,
                              "Name" TEXT NOT NULL,
                              "Value" INTEGER NOT NULL,
                              "MoodCategoryId" TEXT NOT NULL,
                              CONSTRAINT "FK_MoodTopics_MoodCategories_MoodCategoryId" FOREIGN KEY ("MoodCategoryId") REFERENCES "MoodCategories" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_MoodCategories_MoodReportId" ON "MoodCategories" ("MoodReportId");
CREATE UNIQUE INDEX "IX_MoodReports_PartnerId" ON "MoodReports" ("PartnerId");

CREATE INDEX "IX_MoodTopics_MoodCategoryId" ON "MoodTopics" ("MoodCategoryId");

CREATE INDEX "IX_Partners_SpaceId" ON "Partners" ("SpaceId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240816185552_InitialCreate', '8.0.4');

COMMIT;
