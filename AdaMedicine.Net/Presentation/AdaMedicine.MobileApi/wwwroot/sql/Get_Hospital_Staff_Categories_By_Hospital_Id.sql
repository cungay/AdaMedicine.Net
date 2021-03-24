SELECT DISTINCT 
	sc.Id, 
	sc.CategoryName, 
	sc.ShortName, 
	map.DisplayOrder, 
	StaffCount = (
		SELECT 
			COUNT(*) 
		FROM 
			dbo.HospitalStaff hs 
		WHERE 
			hs.HospitalId = ISNULL(@hospitalId, hs.HospitalId) 
		AND hs.StaffCategoryId = map.StaffCategoryId
	) 
	FROM 
		dbo.StaffCategory sc (NOLOCK) 
	INNER JOIN 
		dbo.Hospital_StaffCategory map(NOLOCK) ON sc.Id = map.StaffCategoryId 
	WHERE 
		sc.Published = @published 
	AND sc.Deleted = @deleted 
	AND map.HospitalId = ISNULL(@hospitalId, map.HospitalId) 
	AND sc.Id = map.StaffCategoryId 
	AND map.StaffCategoryId = ISNULL(@categoryId, map.StaffCategoryId) 
	ORDER BY 
		map.DisplayOrder, sc.Id