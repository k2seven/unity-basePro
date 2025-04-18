-- _ENV = {}
print("start__start")

local GameObject = CS.UnityEngine.GameObject
local AssetBundle = CS.UnityEngine.AssetBundle
local Application = CS.UnityEngine.Application
--test
local obj = GameObject("obj")
if CS and CS.ButtonCubeGenerator then
    -- 给 GameObject 添加 ButtonCubeGenerator 脚本组件
    -- local component = obj:AddComponent(typeof(CS.ButtonCubeGenerator))
    local component = obj:AddComponent(typeof(CS.ButtonCubeGenerator))
    if component then
        print("ButtonCubeGenerator component added successfully.")
    else
        print("Failed to add ButtonCubeGenerator component.")
    end
else
    print("CS or ButtonCubeGenerator is not available.")
end

if AssetBundle then
    print("AssetBundle is available." )
    local image = GameObject.Find("Image")
    if image then
        print("Image found.")
        local path = Application.streamingAssetsPath .. "/art/img"
        print("path:" .. path)
        local assetBundle = AssetBundle.LoadFromFile(path)
        if assetBundle then
            print("AssetBundle loaded successfully.")
            local sptite = assetBundle:LoadAsset("Assets/art/img/NIUniu.png", typeof(CS.UnityEngine.Sprite))
            if sptite then
                print("sptite loaded successfully.")    
                local imageComponent = image:GetComponent(typeof(CS.UnityEngine.UI.Image))  
                imageComponent.sprite = sptite 
            else    
                print("Failed to load sptite.")
            end
        else
            print("Failed to load AssetBundle.")
        end
    else
        print("Image not found.")
    end
end
--
print("end__start")