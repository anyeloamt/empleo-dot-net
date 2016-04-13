BEGIN TRAN

BEGIN TRY 
	UPDATE jo SET CompanyEmail = c.CompanyEmail
					, CompanyLogoUrl = c.CompanyLogoUrl
					, CompanyName = c.CompanyName
					, CompanyUrl = c.CompanyUrl
					, UserProfileId = c.UserProfileId
		FROM JobOpportunities jo
			JOIN Companies c ON (c.CompanyId = jo.CompanyId)
	COMMIT

END TRY

BEGIN CATCH
	ROLLBACK
END CATCH