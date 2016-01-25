DROP TABLE BA_Project.dbo.users;
DROP TABLE BA_Project.dbo.type_of_user;

CREATE TABLE BA_Project.dbo.type_of_user
(	type_of_user_id INT PRIMARY KEY,
	name VARCHAR(50)
);

CREATE TABLE BA_Project.dbo.users
(
	users_id BIGINT PRIMARY KEY,
	username VARCHAR(100) NOT NULL,
	password VARCHAR(100) NOT NULL,
	email VARCHAR(100) NOT NULL,
	type_of_user INT NOT NULL REFERENCES type_of_user
);


--DUMMY DATA

INSERT INTO BA_Project.dbo.type_of_user VALUES(1,'Professor');
INSERT INTO BA_Project.dbo.type_of_user VALUES(2,'Student');
INSERT INTO BA_Project.dbo.type_of_user VALUES(3,'Registrar');
INSERT INTO BA_Project.dbo.type_of_user VALUES(4,'IT Support');

INSERT INTO BA_Project.dbo.users VALUES(1,'MrJohnSmith','MrJohnSmith','john@gmail.co.uk',1);
INSERT INTO BA_Project.dbo.users VALUES(2,'JaneDoe','JaneDoe','jane@doe.com',2);
INSERT INTO BA_Project.dbo.users VALUES(3,'JoeBloggs', 'JoeBloggs', 'joe@bloggs.com',3);
INSERT INTO BA_Project.dbo.users VALUES(4,'Admin','Admin', 'admin@ITSupport.co.uk',4);