DECLARE @company_email VARCHAR(500)
DECLARE @company_name VARCHAR(150)
DECLARE @company_logo_url VARCHAR(500)
DECLARE @company_url VARCHAR(500)
DECLARE @user_profile_id INT

 DECLARE job_opportunities_cursor CURSOR FOR 
	SELECT jo.CompanyEmail
			, jo.CompanyName
			, jo.CompanyLogoUrl
			, jo.CompanyUrl
			, jo.UserProfileId
			FROM JobOpportunities jo

OPEN job_opportunities_cursor

FETCH NEXT FROM job_opportunities_cursor INTO 
	@company_email
	, @company_name
	, @company_logo_url
	, @company_url
	, @user_profile_id

DECLARE @company_id INT

BEGIN TRAN
	BEGIN TRY
		WHILE @@FETCH_STATUS = 0   
		BEGIN	
			SET @company_id = (SELECT TOP 1 CompanyId FROM Companies WHERE CompanyName = @company_name)
			
			IF @company_id IS NULL
				BEGIN
					INSERT INTO Companies 
						(CompanyEmail, CompanyName, CompanyLogoUrl, CompanyUrl, UserProfileId, Created) 
						VALUES (@company_email
							, @company_name
							, @company_logo_url
							, @company_url
							, @user_profile_id
							, GETDATE()
						)

					SET @company_id = (SELECT TOP 1 CompanyId FROM Companies WHERE CompanyName = @company_name)
				END
			
			UPDATE JobOpportunities SET CompanyId = @company_id
				WHERE CompanyName = @company_name

			FETCH NEXT FROM job_opportunities_cursor INTO 
				@company_email
				, @company_name
				, @company_logo_url
				, @company_url
				, @user_profile_id

		END
		
		COMMIT TRAN

	END TRY

	BEGIN CATCH
		ROLLBACK
	END CATCH

CLOSE job_opportunities_cursor
DEALLOCATE job_opportunities_cursor