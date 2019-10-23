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
	'Département d''informatique',
	'Le français est important. Les retards aussi',
	'11111'
),
(
	'Département des sciences sociales',
	'Le français est important. Les retards ne le sont pas.',
	'22222'
),
(
	'Département de français',
	'Le français est important. Les retard blabla',
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
	'Programmation et sécurité',
	'Dans le domaine du développement d’applications, les techniciennes et les techniciens participent à la conception d’applications fonctionnant sur différentes plateformes et en effectuent le développement  et la maintenance. Les applications développées contribuent à des domaines variés dans presque tous les secteurs d’activité où l’intégrité de ses données est la base de la conception.',
	'AA',
	'11111'
),
(
	'420.B0.RC',
	1,
	'Réseaux et cybersécurité',
	'Dans le domaine de l’administration des réseaux informatiques, les techn iciennes et les techniciens participent à la conception de réseaux, en effectuent l’installation, en fait sa gestion et la sécurisation de ses serveurs et ordinateurs. Leur tâche consiste aussi à assurer le fonctionnement des services Internet et intranet  qui y sont liés, tels le partage de ressources, la communication, l’hébergement, la téléphonie, etc.',
	'BB',
	'22222'
),
(
	'ZZZ.ZZ.FR',
	3,
	'Formation générale/Français',
	'Dans la vie, il est important de bien écrire. C''est pourquoi le programe de français existe.',
	'CC',
	'33333'
)
GO