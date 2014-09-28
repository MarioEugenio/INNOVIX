[T4Scaffolding.Scaffolder(Description = "Cria um serviço")][CmdletBinding()]
param(
    [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelName,
    [switch]$HasOptions,
    [string]$Project,
    [string]$CodeLanguage,
    [string[]]$TemplateFolders,
    [switch]$Force = $false
)

$outputPathRepositoryInterface = "Repository\I$ModelName" + "Repository" 
$outputPathRepositoryImplementation = "Repository\$ModelName" + "Repository"

if ($ModelName) {
	$foundModelType = Get-ProjectType -Project Innovix.Base.Domain $ModelName
	if (!$foundModelType) { return }
}

if ($foundModelType) { $relatedEntities = [Array](Get-RelatedEntities $foundModelType.FullName -Project $project) }
if ($foundModelType) { $nomePlural = Get-PluralizedWord $foundModelType.Name }
if (!$relatedEntities) { $relatedEntities = @() }


 
Add-ProjectItemViaTemplate $outputPathRepositoryInterface -Template IRepositoryTemplate `
    -Model @{ ModelName = $ModelName; 
		HasOptions = $HasOptions.IsPresent; 
		ModelType = [MarshalByRefObject]$foundModelType; 
		ViewDataType = [MarshalByRefObject]$foundModelType;
		ViewDataTypeName = $foundModelType.Name;
		EntityName = $ModelName;
		ViewDataTypeNamePlural = $nomePlural;
		RelatedEntities = $relatedEntities;
	} `
    -SuccessMessage "Interface do repositório criada em Innovix.Base.Data -> {0}" `
    -TemplateFolders $TemplateFolders -Project "Innovix.Base.Data" -CodeLanguage $CodeLanguage -Force:$Force


Add-ProjectItemViaTemplate $outputPathRepositoryImplementation -Template RepositoryImplTemplate `
    -Model @{ ModelName = $ModelName; 
		HasOptions = $HasOptions.IsPresent; 
		ModelType = [MarshalByRefObject]$foundModelType; 
		ViewDataType = [MarshalByRefObject]$foundModelType;
		ViewDataTypeName = $foundModelType.Name;
		EntityName = $ModelName;
		ViewDataTypeNamePlural = $nomePlural;
		RelatedEntities = $relatedEntities;
	} `
    -SuccessMessage "Implementação do repositório criada em Innovix.Base.Data.NHibernate -> {0}" `
    -TemplateFolders $TemplateFolders -Project "Innovix.Base.Data.NHibernate" -CodeLanguage $CodeLanguage -Force:$Force
 
