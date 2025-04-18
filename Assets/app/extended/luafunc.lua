-- This is a new Lua script.
-- 重写print展示执行脚本行数
print("start__luafunc")
local env = _ENV
local re_print = function (...)
    local info = debug.getinfo(2, "Sl") -- 获取调用者的文件名和行号
    local filename = info.short_src
    local line = info.currentline
    _G.print(string.format("[%s:%d] %s", filename, line, table.concat({...}, "\t")))
end


local tableToString
tableToString = function (tbl,indent)
    indent = indent or 0
    local result = ""
    local indentStr = string.rep("  ", indent)

    result = result .. "{\n"
    for k, v in pairs(tbl) do
        result = result .. indentStr .. "  "
        if type(k) == "string" then
            result = result .. k .. " = "
        else
            result = result .. "[" .. tostring(k) .. "] = "
        end

        if type(v) == "table" then
            result = result .. tableToString(v, indent + 1)
        else
            result = result .. tostring(v)
        end
        result = result .. ",\n"
    end
    result = result .. indentStr .. "}"
    return result
end

-- 重写printt打印table
local re_printt = function(...)
    local info = debug.getinfo(2, "Sl") -- 获取调用者的文件名和行号
    local filename = info.short_src
    local line = info.currentline
    local args = {...}
    for i, arg in ipairs(args) do
        if type(arg) == "table" then
            args[i] = tableToString(arg)
        end 
    end
    _G.print(string.format("[%s:%d] %s", filename, line, table.concat(args, "\t")))
end

print("end__luafunc")
return {
    printt = re_printt,
    print = re_print
}