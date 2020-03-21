﻿using System;
using FluentAssertions;
using Xunit;

namespace CSharp.Rop.Generic.Result.Tests
{
    public class TapIf : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_executes_action_conditionally_and_returns_self(bool condition)
        {
            var result = Result.Success();
            var actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_action_conditionally_and_returns_self(bool condition)
        {
            var result = Result.Success(T.Value);
            var actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_action_T_conditionally_and_returns_self(bool condition)
        {
            var result = Result.Success(T.Value);
            var actionExecuted = false;
            Action<T> action = (T _) => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_executes_func_conditionally_and_returns_self(bool condition)
        {
            var result = Result.Success();
            var actionExecuted = false;
            Func<Discard> func = () => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_func_conditionally_and_returns_self(bool condition)
        {
            var result = Result.Success(T.Value);
            var actionExecuted = false;
            Func<Discard> func = () => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_func_T_conditionally_and_returns_self(bool condition)
        {
            var result = Result.Success(T.Value);
            var actionExecuted = false;
            Func<T, Discard> func = (T _) => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

    }
}