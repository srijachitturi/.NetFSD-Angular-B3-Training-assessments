CREATE DATABASE EventDb;
USE EventDb;

--CREATING USER INFO
CREATE TABLE UserInfo
(
    EmailId VARCHAR(100) PRIMARY KEY,

    UserName VARCHAR(50) NOT NULL,

    Role VARCHAR(20) NOT NULL 
        CHECK (Role IN ('Admin', 'Participant')),

    Password VARCHAR(20) NOT NULL
        CHECK (LEN(Password) BETWEEN 6 AND 20)
);
SELECT * FROM dbo.UserInfo;

-- Insert User
INSERT INTO UserInfo VALUES
('pavan@gmail.com','pavan','Admin','admin123'),
('srija@gmail.com','Srija','Participant','pass123');

--CREATING EVENT DETAILS
CREATE TABLE EventDetails
(
	EventId        INT PRIMARY KEY,
	EventName      VARCHAR(50)  NOT NULL 
	   CHECK (LEN(EventName) BETWEEN 1 AND 50),
	EventCategory  VARCHAR(50)  NOT NULL 
	   CHECK (LEN(EventCategory) BETWEEN 1 AND 50),
	EventDate      DATETIME     NOT NULL,
	Description    VARCHAR(500),
	Status         VARCHAR(10)  NOT NULL 
	   CHECK (Status IN ('Active','In-Active'))
);
SELECT * FROM dbo.EventDetails;

--INSERT EVENT DETAILS
INSERT INTO EventDetails 
(EventId, EventName, EventCategory, EventDate, Description, Status)
VALUES
(130,'HTML Intro','Tech','2026-04-15 10:00:00','Basic HTML','Active'),
(131,'Yoga Class','Health','2026-04-16 06:30:00','Morning yoga','Active'),
(132,'Resume Tips','Career','2026-04-18 02:00:00','Resume help','Active'),
(133,'Music Jam','Fun','2026-04-20 06:00:00','Small music','In-Active');

--CREATING SPEAKER DETAILS
CREATE TABLE SpeakersDetails
(
	SpeakerId    INT PRIMARY KEY,
	SpeakerName  VARCHAR(50) NOT NULL 
	   CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);
SELECT * FROM dbo.SpeakersDetails;

--INSERT SPEAKER DETAILS
 INSERT INTO SpeakersDetails (SpeakerId, SpeakerName) VALUES
(201,'Dr. John Smith'),
(202,'Ms. Priya Sharma'),
(203,'Mr. Arjun Reddy'),
(204,'Mrs. Kavita Rao'),
(205,'Mr. David Lee');

--CREATING SESSION INFO
CREATE TABLE SessionInfo
(
	SessionId     INT PRIMARY KEY,
	EventId       INT NOT NULL,
	SessionTitle  VARCHAR(50) NOT NULL 
	   CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),
	SpeakerId     INT NOT NULL,
	Description   VARCHAR(500),
	SessionStart  DATETIME NOT NULL,
	SessionEnd    DATETIME NOT NULL,
	SessionUrl    VARCHAR(300),

	FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
	FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId),

	CHECK (SessionEnd > SessionStart)
);
SELECT * FROM dbo.SessionInfo;

-- INSERT SESSION INFO
INSERT INTO SessionInfo
(SessionId, EventId, SessionTitle, SpeakerId, Description, SessionStart, SessionEnd, SessionUrl)
VALUES
(301,130,'HTML Tags',201,'Basic HTML tags',
 '2026-04-15 10:00:00','2026-04-15 11:00:00','www.html.com'),

(302,131,'Yoga Basics',204,'Intro to yoga',
 '2026-04-16 06:30:00','2026-04-16 07:30:00','www.yoga.com'),

(303,132,'Resume Format',202,'How to format resume',
 '2026-04-18 14:00:00','2026-04-18 15:00:00','www.resume.com'),

(304,133,'Music Intro',205,'Music practice session',
 '2026-04-20 18:00:00','2026-04-20 19:00:00','www.music.com');

--CREATING PARTICIPANT EVENTDETAILS
CREATE TABLE ParticipantEventDetails
(
	Id                 INT PRIMARY KEY,
	ParticipantEmailId VARCHAR(100) NOT NULL,
	EventId            INT NOT NULL,
	SessionId          INT NOT NULL,
	IsAttended         BIT NOT NULL 
	    CHECK (IsAttended IN (0,1)),

	FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
	FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
	FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);
SELECT * FROM dbo.ParticipantEventDetails;

--INSERT PARTICIPANT EVENT DEATILS
INSERT INTO ParticipantEventDetails
(Id, ParticipantEmailId, EventId, SessionId, IsAttended)
VALUES
(1,'srija@gmail.com',130,301,1),
(2,'srija@gmail.com',131,302,1),
(3,'pavan@gmail.com',132,303,0),
(4,'pavan@gmail.com',133,304,1);