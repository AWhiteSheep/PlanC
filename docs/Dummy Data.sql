USE PCU001
GO


INSERT INTO TDPTMNT
(
	DPTMNT_TITLE,
	DPTMNT_PLCY,
	TRK_UID
)
VALUES
(
	'D�partement d''informatique',
	'Le fran�ais est important. Les retards aussi',
	'11111'
),
(
	'D�partement des sciences sociales',
	'Le fran�ais est important. Les retards ne le sont pas.',
	'22222'
),
(
	'D�partement de fran�ais',
	'Le fran�ais est important. Les retard blabla',
	'33333'
)
GO


INSERT INTO TPGM
(
	PGM_ID,
	DPTMNT_ID,
	PGM_TITLE,
	PGM_DESC,
	PGM_TY_CD,
	TRK_UID)
VALUES
(
	'420.B0.PS',
	1,
	'Programmation et s�curit�',
	'Dans le domaine du d�veloppement d�applications, les techniciennes et les techniciens participent � la conception d�applications fonctionnant sur diff�rentes plateformes et en effectuent le d�veloppement  et la maintenance. Les applications d�velopp�es contribuent � des domaines vari�s dans presque tous les secteurs d�activit� o� l�int�grit� de ses donn�es est la base de la conception.',
	'AA',
	'11111'
),
(
	'420.B0.RC',
	1,
	'R�seaux et cybers�curit�',
	'Dans le domaine de l�administration des r�seaux informatiques, les techn iciennes et les techniciens participent � la conception de r�seaux, en effectuent l�installation, en fait sa gestion et la s�curisation de ses serveurs et ordinateurs. Leur t�che consiste aussi � assurer le fonctionnement des services Internet et intranet  qui y sont li�s, tels le partage de ressources, la communication, l�h�bergement, la t�l�phonie, etc.',
	'BB',
	'22222'
),
(
	'ZZZ.ZZ.FR',
	3,
	'Formation g�n�rale/Fran�ais',
	'Dans la vie, il est important de bien �crire. C''est pourquoi le programe de fran�ais existe.',
	'CC',
	'33333'
)
GO