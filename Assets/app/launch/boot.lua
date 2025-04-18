
print("start__boot")
local dataPath = CS.UnityEngine.Application.dataPath
package.cpath  = package.cpath  .. ';;' .. dataPath .. '/?.dll' print(dataPath)
xpcall(
    function()
        local dbg = require('emmy_core')
        dbg.tcpConnect('localhost', 7771)
    end, 
    function()
        print('IDE没有开启调试')

        end
    )
local currentDir = CS.System.IO.Directory.GetCurrentDirectory()
print("当前工作目录: " .. currentDir)
local dataPath = CS.UnityEngine.Application.dataPath
package.path = package.path .. ";;" .. dataPath .. "/?.lua"

-- 创建新的环境变量但是内部环境不可以污染上层环境变量
local env = {}
setmetatable(env,{__index = _G})

local luafunc, err = loadfile("Assets/app/extended/luafunc.lua","t", env)
if not luafunc then
    error("Error loading file: " .. err)
end

local api = luafunc()
env.print = api.print
env.printt = api.printt

local fileFunc, err = loadfile("Assets/app/start/src/start.lua","t", env)
if not fileFunc then
    error("Error loading file: " .. err)
end

fileFunc()

print("end__boot")
