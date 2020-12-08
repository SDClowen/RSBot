@echo off

echo "Cleaning Application"
rmdir /s /q "Application/RoadShark/bin"
rmdir /s /q "Application/RoadShark/obj"

rmdir /s /q "Application/RoadShark.Replacer/bin"
rmdir /s /q "Application/RoadShark.Replacer/obj"

rmdir /s /q "Application/RoadShark.Loader/Release"

echo "Cleaning Bots"
rmdir /s /q "Botbases/RoadShark.Bot.Default/bin"
rmdir /s /q "Botbases/RoadShark.Bot.Default/obj"

echo "Cleaning Plugins"
rmdir /s /q "Plugins/RoadShark.Chat/bin"
rmdir /s /q "Plugins/RoadShark.Chat/obj"

rmdir /s /q "Plugins/RoadShark.General/bin"
rmdir /s /q "Plugins/RoadShark.General/obj"

rmdir /s /q "Plugins/RoadShark.Inventory/bin"
rmdir /s /q "Plugins/RoadShark.Inventory/obj"

rmdir /s /q "Plugins/RoadShark.Log/bin"
rmdir /s /q "Plugins/RoadShark.Log/obj"

rmdir /s /q "Plugins/RoadShark.Map/bin"
rmdir /s /q "Plugins/RoadShark.Map/obj"

rmdir /s /q "Plugins/RoadShark.Party/bin"
rmdir /s /q "Plugins/RoadShark.Party/obj"

rmdir /s /q "Plugins/RoadShark.Protection/bin"
rmdir /s /q "Plugins/RoadShark.Protection/obj"

rmdir /s /q "Plugins/RoadShark.Shopping/bin"
rmdir /s /q "Plugins/RoadShark.Shopping/obj"

rmdir /s /q "Plugins/RoadShark.Skills/bin"
rmdir /s /q "Plugins/RoadShark.Skills/obj"

rmdir /s /q "Plugins/RoadShark.LanguageWizard/bin"
rmdir /s /q "Plugins/RoadShark.LanguageWizard/obj"


echo "Cleaning Libraries"
rmdir /s /q "Library/RoadShark.Core/bin"
rmdir /s /q "Library/RoadShark.Core/obj"

rmdir /s /q "Library/RoadShark.Pk2/bin"
rmdir /s /q "Library/RoadShark.Pk2/obj"

rmdir /s /q "Library/RoadShark.Loader.Library/Release"
rmdir /s /q "Library/RoadShark.Theme/bin"
rmdir /s /q "Library/RoadShark.Theme/obj"

echo "Cleaning Build"
rmdir /s /q "Build/Release"
rmdir /s /q "Build/Cache"

del /S "Build\*.config"
del /S "Build\*.pdb"
del /S "Build\*.ini"
del /S "Build\User\Log\*.txt"
del /S "Build\*.iobj"
del /S "Build\*.ipdb"
del /S "Build\*.exp"
del /S "Build\*.lib"
rmdir /s /q "Build/Release"
pause