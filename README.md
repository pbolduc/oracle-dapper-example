
# Create Database

* Start the Oracle Docker image by running `docker-compose up -d`

* Download Oracle DB Sample Schemas - https://github.com/oracle-samples/db-sample-schemas
* Connect to the local oracle database using SQL Developer with
  * Username: `SYS AS SYSDBA`
  * Password: `pwZy2D7C74` (matches docker-compose.yaml)
  * Hostname: `localhost`
  * Port: `1521`
  * SID: `FREE`

* Install human_resources sample by opening `sql/hr_install.sql` and running as sysdba

    * Password for HR: `HR`
    * Tablespace for HR: leave blank to accept default
    * Overwrite: `YES`

