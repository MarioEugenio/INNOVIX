[T4Scaffolding.Scaffolder(Description = "Cria um serviço")][CmdletBinding()]
param(
    [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelName,
    [switch]$HasOptions,
    [string]$Project,
    [string]$CodeLanguage,
    [string[]]$TemplateFolders,
    [switch]$Force = $false
)

$outputPathServiceInterface = "Service\I$ModelName" + "Service"
$outputPathServiceImplementation = "Service\$ModelName" + "Service"

if ($ModelName) {
	$foundModelType = Get-ProjectType -Project Innovix.Base.Domain $ModelName
	if (!$foundModelType) { return }
}

if ($foundModelType) { $relatedEntities = [Array](Get-RelatedEntities $foundModelType.FullName -Project $project) }
if ($foundModelType) { $nomePlural = Get-PluralizedWord $foundModelType.Name }
if (!$relatedEntities) { $relatedEntities = @() }


 
Add-ProjectItemViaTemplate $outputPathServiceInterface -Template IServiceTemplate `
    -Model @{ ModelName = $ModelName; 
		HasOptions = $HasOptions.IsPresent; 
		ModelType = [MarshalByRefObject]$foundModelType; 
		ViewDataType = [MarshalByRefObject]$foundModelType;
		ViewDataTypeName = $foundModelType.Name;
		EntityName = $ModelName;		
		ViewDataTypeNamePlural = $nomePlural;
		RelatedEntities = $relatedEntities;
	} `
    -SuccessMessage "Interface do Servico criada em {0}" `
    -TemplateFolders $TemplateFolders -Project "Innovix.Base.Domain" -CodeLanguage $CodeLanguage -Force:$Force


Add-ProjectItemViaTemplate $outputPathServiceImplementation -Template ServiceImplTemplate `
    -Model @{ ModelName = $ModelName; 
		HasOptions = $HasOptions.IsPresent; 
		ModelType = [MarshalByRefObject]$foundModelType; 
		ViewDataType = [MarshalByRefObject]$foundModelType;
		ViewDataTypeName = $foundModelType.Name;
		EntityName = $ModelName;
		ViewDataTypeNamePlural = $nomePlural;
		RelatedEntities = $relatedEntities;
	} `
    -SuccessMessage "Implementacao do Servico criada em {0}" `
    -TemplateFolders $TemplateFolders -Project "Innovix.Base.Domain.Service.Impl" -CodeLanguage $CodeLanguage -Force:$Force
 
